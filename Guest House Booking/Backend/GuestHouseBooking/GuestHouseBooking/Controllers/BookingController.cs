using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userResolver;
        private readonly IEmailService _emailService;
        private readonly IAuditLogService _auditLog;
        private readonly IConfiguration _config; // <-- 1. Inject IConfiguration

        public BookingController(ApplicationDbContext context,
                                 UserResolverService userResolver,
                                 IEmailService emailService,
                                 IAuditLogService auditLog,
                                 IConfiguration config) // <-- 2. Get it here
        {
            _context = context;
            _userResolver = userResolver;
            _emailService = emailService;
            _auditLog = auditLog;
            _config = config; // <-- 3. Assign it
        }

        // --- Endpoints for Booking Form Dropdowns (for Users) ---

        [HttpGet("guesthouses")]
        public async Task<ActionResult<IEnumerable<GuestHouseDto>>> GetGuesthouseList()
        {
            // --- FIX FOR IMAGES ---
            // The old code only selected ID and Name.
            // This new code selects everything you need for the card.
            return await _context.GuestHouses
                .Where(g => !g.Deleted)
                .Select(g => new GuestHouseDto // We can re-use the full DTO
                {
                    GuestHouseId = g.GuestHouseId,
                    Name = g.Name,
                    Location = g.Location,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl // <-- The missing property
                })
                .ToListAsync();
        }

        [HttpGet("rooms-by-guesthouse/{guesthouseId}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomList(int guesthouseId)
        {
            // This endpoint is correct as-is.
            return await _context.Rooms
                .Where(r => r.GuestHouseId == guesthouseId && !r.Deleted)
                .Select(r => new RoomDto { RoomId = r.RoomId, RoomName = r.RoomName, GenderAllowed = r.GenderAllowed })
                .ToListAsync();
        }

        [HttpGet("available-beds")]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetAvailableBeds(
            [FromQuery] int roomId,
            [FromQuery] DateTime dateFrom,
            [FromQuery] DateTime dateTo)
        {
            // This logic is correct as-is.
            var allBedIdsInRoom = await _context.Beds
                .Where(b => b.RoomId == roomId && !b.Deleted)
                .Select(b => b.BedId)
                .ToListAsync();

            // --- THIS IS THE FIX ---
            // We must compare the .Date part only, to ignore time-of-day / time zone issues.
            var bookedBedIds = await _context.Bookings
                .Where(b => b.RoomId == roomId &&
                            (b.Status == "Approved" || b.Status == "Pending") &&
                            b.DateFrom.Date < dateTo.Date && // <-- Use .Date
                            b.DateTo.Date > dateFrom.Date)   // <-- Use .Date
                .Select(b => b.BedId)
                .Distinct()
                .ToListAsync();

            var availableBedIds = allBedIdsInRoom.Except(bookedBedIds);

            return await _context.Beds
                .Where(b => availableBedIds.Contains(b.BedId))
                .Select(b => new BedDto { BedId = b.BedId, BedNumber = b.BedNumber, RoomId = b.RoomId })
                .ToListAsync();
        }

        // --- User Booking Endpoints ---

        [HttpPost("create")]
        [Authorize(Roles = "User")] // Allow lowercase "user"
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            // --- 1. WRAP THE ENTIRE METHOD IN A TRY...CATCH ---
            try
            {
                var userId = _userResolver.GetUserId();
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                {
                    return Unauthorized();
                }

                // Conflict Check
                // --- THIS IS THE FIX ---
                // Conflict Check, must also use .Date
                var isBedStillAvailable = !await _context.Bookings
                    .AnyAsync(b => b.BedId == dto.BedId &&
                                   (b.Status == "Approved" || b.Status == "Pending") &&
                                   b.DateFrom.Date < dto.DateTo.Date && // <-- Use .Date
                                   b.DateTo.Date > dto.DateFrom.Date);  // <-- Use .Date

                if (!isBedStillAvailable)
                {
                    return Conflict(new { message = "Sorry, this bed was just booked by someone else. Please try again." });
                }

                var booking = new Booking
                {
                    UserId = userId,
                    GuestHouseId = dto.GuestHouseId,
                    RoomId = dto.RoomId,
                    BedId = dto.BedId,
                    DateFrom = dto.DateFrom,
                    DateTo = dto.DateTo,
                    Status = "Pending",
                    Remarks = string.Empty, // <-- THIS IS THE FIX
                    CreatedBy = userId,
                    CreatedDate = DateTime.UtcNow
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync(); // <-- This is the likely crash point

                // --- Admin Notification Logic (already has its own try/catch) ---
                try
                {
                    var adminEmail = _config["AdminEmail"];
                    if (!string.IsNullOrEmpty(adminEmail))
                    {
                        var emailBody = $"A new booking request has been submitted by {user.UserName} (Email: {user.Email}).<br><br>" +
                                        $"Booking ID: {booking.BookingId}<br>" +
                                        $"Please log in to the admin panel to approve or reject this request.";

                        await _emailService.SendEmailAsync(adminEmail, "New Booking Request Submitted", emailBody);

                        _context.EmailNotificationLogs.Add(new EmailNotificationLog
                        {
                            ToEmail = adminEmail,
                            Subject = "New Booking Request Submitted",
                            SentDate = DateTime.UtcNow,
                            BookingId = booking.BookingId
                        });
                        await _context.SaveChangesAsync();
                    }
                }
                catch (Exception emailEx)
                {
                    Console.WriteLine($"Failed to send admin notification email: {emailEx.Message}");
                }

                return Ok(new { message = "Booking request submitted. Pending approval." });
            }
            catch (Exception ex)
            {
                // --- 2. THIS CATCH BLOCK IS THE FIX ---
                // It will catch the crash and send the real error message to your browser.
                // ex.InnerException often has the specific SQL error.
                Console.WriteLine($"Error creating booking: {ex.ToString()}");
                return StatusCode(500, new { message = "An internal server error occurred.", details = ex.Message, innerException = ex.InnerException?.Message });
            }
        }



        [HttpGet("my-bookings")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetMyBookings()
        {
            var userId = _userResolver.GetUserId();

            return await _context.Bookings
                .Where(b => b.UserId == userId && !b.Deleted)
                .Include(b => b.User)
                .Include(b => b.GuestHouse)
                .Include(b => b.Room)
                .Include(b => b.Bed)
                .OrderByDescending(b => b.CreatedDate)
                .Select(b => new BookingDto // <-- Manual mapping
                {
                    BookingId = b.BookingId,
                    UserName = b.User.UserName,
                    GuestHouseName = b.GuestHouse.Name,
                    RoomName = b.Room.RoomName,
                    BedNumber = b.Bed.BedNumber,
                    DateFrom = b.DateFrom,
                    DateTo = b.DateTo,
                    Status = b.Status,
                    Remarks = b.Remarks,
                    CreatedDate = b.CreatedDate
                })
                .ToListAsync();
        }


        // --- Admin Booking Management Endpoints ---

        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
        {
            return await _context.Bookings
                .Where(b => !b.Deleted)
                .Include(b => b.User)
                .Include(b => b.GuestHouse)
                .Include(b => b.Room)
                .Include(b => b.Bed)
                .OrderByDescending(b => b.CreatedDate)
                .Select(b => new BookingDto // Same DTO, just a different query
                {
                    BookingId = b.BookingId,
                    UserName = b.User.UserName,
                    GuestHouseName = b.GuestHouse.Name,
                    RoomName = b.Room.RoomName,
                    BedNumber = b.Bed.BedNumber,
                    DateFrom = b.DateFrom,
                    DateTo = b.DateTo,
                    Status = b.Status,
                    Remarks = b.Remarks,
                    CreatedDate = b.CreatedDate
                })
                .ToListAsync();
        }

        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveBooking(int id)
        {
            var booking = await _context.Bookings.Include(b => b.User).FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null) return NotFound();

            // TODO: Check for conflicts *before* approving

          

        // --- FIX FOR ApproveBooking ---
        var isBedStillAvailable = !await _context.Bookings
            .AnyAsync(b => b.BookingId != id && // <-- Don't check against itself
                   b.BedId == booking.BedId &&
                   b.Status == "Approved" &&
                   b.DateFrom < booking.DateTo &&
                   b.DateTo > booking.DateFrom);

            if (!isBedStillAvailable)
            {
                // If a conflict is found, reject this booking instead
                booking.Status = "Rejected";
                booking.Remarks = "Auto-rejected due to a conflict with an existing approved booking.";
                await _context.SaveChangesAsync();

                // Send email to user
                await _emailService.SendEmailAsync(booking.User.Email, "Booking Rejected", booking.Remarks);

                return Conflict(new { message = "Booking could not be approved due to a conflict." });
            }
            booking.Status = "Approved";
            booking.ModifiedBy = _userResolver.GetUserId();
            booking.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Send email to user
            await _emailService.SendEmailAsync(booking.User.Email, "Booking Approved",
                $"Your booking (ID: {booking.BookingId}) has been approved.");

            // Log this email
            _context.EmailNotificationLogs.Add(new EmailNotificationLog
            {
                BookingId = booking.BookingId,
                ToEmail = booking.User.Email,
                Subject = "Booking Approved",
                SentDate = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            // --- ADD AUDIT LOG ---
            await _auditLog.LogAction("Approve Booking", booking.ModifiedBy.Value, $"Booking {booking.BookingId} set to Approved.", "Pending");
            // --- END OF FIX ---

            return Ok(new { message = "Booking approved and user notified." });
        }


        [HttpPut("reject/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectBooking(int id, [FromBody] BookingRejectDto dto)
        {
            var booking = await _context.Bookings.Include(b => b.User).FirstOrDefaultAsync(b => b.BookingId == id);
            if (booking == null) return NotFound();

            booking.Status = "Rejected";
            booking.Remarks = dto.Remarks; // <-- Add the reason
            booking.ModifiedBy = _userResolver.GetUserId();
            booking.ModifiedDate = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Send email to user
            await _emailService.SendEmailAsync(booking.User.Email, "Booking Rejected",
                $"Your booking (ID: {booking.BookingId}) has been rejected. Reason: {dto.Remarks}");

            // Log this email
            _context.EmailNotificationLogs.Add(new EmailNotificationLog
            {
                BookingId = booking.BookingId,
                ToEmail = booking.User.Email,
                Subject = "Booking Rejected",
                SentDate = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            // --- ADD AUDIT LOG ---
            await _auditLog.LogAction("Reject Booking", booking.ModifiedBy.Value, $"Booking {booking.BookingId} set to Rejected. Reason: {dto.Remarks}", "Pending");
            // --- END OF FIX ---

            return Ok(new { message = "Booking rejected and user notified." });
        }

    }
}
