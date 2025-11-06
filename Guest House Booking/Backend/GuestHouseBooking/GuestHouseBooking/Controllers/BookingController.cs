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
        private readonly IAuditLogService _auditLog; // <-- 1. Add this

        public BookingController(ApplicationDbContext context, UserResolverService userResolver, IEmailService emailService, IAuditLogService auditLog)
        {
            _context = context;
            _userResolver = userResolver;
            _emailService = emailService;
            _auditLog = auditLog;
            
        }

        // --- Endpoints for Booking Form Dropdowns (for Users) ---

        [HttpGet("guesthouses")]
        public async Task<ActionResult<IEnumerable<GuestHouseDto>>> GetGuesthouseList()
        {
            // Any logged-in user can get a list of guesthouses
            return await _context.GuestHouses
                .Where(g => !g.Deleted)
                .Select(g => new GuestHouseDto { GuestHouseId = g.GuestHouseId, Name = g.Name })
                .ToListAsync();
        }

        [HttpGet("rooms-by-guesthouse/{guesthouseId}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomList(int guesthouseId)
        {
            // Get rooms for the selected guesthouse
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
            // --- This is your "Bed Availability Check" logic ---

            // 1. Get ALL bed IDs in the selected room
            var allBedIdsInRoom = await _context.Beds
                .Where(b => b.RoomId == roomId && !b.Deleted)
                .Select(b => b.BedId)
                .ToListAsync();

            // 2. Get all bed IDs that are *already booked* (and approved)
            //    in that room for the overlapping dates.
            var bookedBedIds = await _context.Bookings
                .Where(b => b.RoomId == roomId &&
                            b.Status == "Approved" && // Only count approved bookings
                            b.DateFrom < dateTo && // Check for date overlap
                            b.DateTo > dateFrom)
                .Select(b => b.BedId)
                .Distinct()
                .ToListAsync();

            // 3. Find the beds that are NOT in the booked list
            var availableBedIds = allBedIdsInRoom.Except(bookedBedIds);

            // 4. Return the details for the available beds
            return await _context.Beds
                .Where(b => availableBedIds.Contains(b.BedId))
                .Select(b => new BedDto { BedId = b.BedId, BedNumber = b.BedNumber, RoomId = b.RoomId })
                .ToListAsync();
        }


        // --- User Booking Endpoints ---

        [HttpPost("create")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            var userId = _userResolver.GetUserId();

            // TODO: Add a final check here to make sure the bed is *still* available
            // (in case someone booked it in the 2 seconds it took to submit)

            var booking = new Booking
            {
                UserId = userId,
                GuestHouseId = dto.GuestHouseId,
                RoomId = dto.RoomId,
                BedId = dto.BedId,
                DateFrom = dto.DateFrom,
                DateTo = dto.DateTo,
                Status = "Pending", // <-- Default status
                CreatedBy = userId,
                CreatedDate = DateTime.UtcNow
            };

            // --- FIX FOR CreateBooking ---
            var isBedStillAvailable = !await _context.Bookings
                .AnyAsync(b => b.BedId == dto.BedId &&
                               b.Status == "Approved" &&
                               b.DateFrom < dto.DateTo &&
                               b.DateTo > dto.DateFrom);

            if (!isBedStillAvailable)
            {
                return Conflict(new { message = "Sorry, this bed was just booked by someone else. Please try another." });
            }

            _context.Bookings.Add(booking);

            await _context.SaveChangesAsync();

            // TODO: Email Admin about new request
            // await _emailService.SendEmailAsync("admin@example.com", "New Booking Request", ...);


            // --- FIX FOR ADMIN EMAIL ---
            // You can get this email from IConfiguration (appsettings.json)
            var adminEmail = "rishabhsguesthouse@gmail.com";
            var user = await _context.Users.FindAsync(userId);
            await _emailService.SendEmailAsync(adminEmail,
                "New Booking Request",
                $"A new booking (ID: {booking.BookingId}) was submitted by {user.UserName} for bed {dto.BedId}.");
            // --- END OF FIX ---


            return Ok(new { message = "Booking request submitted. Pending approval." });
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
