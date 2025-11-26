using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
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
        // Repositories
        private readonly IBookingRepository _bookingRepo;
        private readonly IGuestHouseRepository _guestHouseRepo;
        private readonly IRoomRepository _roomRepo;
        private readonly IBedRepository _bedRepo;

        // Services
        private readonly UserResolverService _userResolver;
        private readonly IEmailService _emailService;
        private readonly IAuditLogService _auditLog;
        private readonly IConfiguration _config;
        private readonly IUserRepository _userRepo;

        public BookingController(
            IBookingRepository bookingRepo,
            IGuestHouseRepository guestHouseRepo,
            IRoomRepository roomRepo,
            IBedRepository bedRepo,
            IUserRepository userRepo,
            UserResolverService userResolver,
            IEmailService emailService,
            IAuditLogService auditLog,
            IConfiguration config)
        {
            _bookingRepo = bookingRepo;
            _guestHouseRepo = guestHouseRepo;
            _roomRepo = roomRepo;
            _bedRepo = bedRepo;
            _userRepo = userRepo;
            _userResolver = userResolver;
            _emailService = emailService;
            _auditLog = auditLog;
            _config = config;
        }


        [HttpGet("guesthouses")]
        public async Task<ActionResult<IEnumerable<GuestHouseDto>>> GetGuesthouseList()
        {

            var guesthouses = await _guestHouseRepo.GetAllActiveAsync();

            return Ok(guesthouses.Select(g => new GuestHouseDto
            {
                GuestHouseId = g.GuestHouseId,
                Name = g.Name,
                Location = g.Location,
                Description = g.Description,
                ImageUrl = g.ImageUrl
            }));
        }

        [HttpGet("rooms-by-guesthouse/{guesthouseId}")]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRoomList(int guesthouseId)
        {
            var rooms = await _roomRepo.GetRoomsByGuestHouseAsync(guesthouseId);

            return Ok(rooms.Select(r => new RoomDto
            {
                RoomId = r.RoomId,
                RoomName = r.RoomName,
                GenderAllowed = r.GenderAllowed
            }));
        }

        [HttpGet("available-beds")]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetAvailableBeds(
            [FromQuery] int roomId,
            [FromQuery] DateTime dateFrom,
            [FromQuery] DateTime dateTo)
        {
            // 1. Get all beds in room
            var allBeds = await _bedRepo.GetBedsByRoomAsync(roomId);

            // 2. Get IDs of booked beds (Logic is now hidden in Repo)
            var bookedBedIds = await _bookingRepo.GetBookedBedIdsAsync(roomId, dateFrom, dateTo);

            // 3. Filter
            var availableBeds = allBeds.Where(b => !bookedBedIds.Contains(b.BedId));

            return Ok(availableBeds.Select(b => new BedDto
            {
                BedId = b.BedId,
                BedNumber = b.BedNumber,
                RoomId = b.RoomId
            }));
        }


        [HttpPost("create")]
        [Authorize(Roles = "User")] 
        public async Task<IActionResult> CreateBooking([FromBody] BookingCreateDto dto)
        {
            try
            {
                var userId = _userResolver.GetUserId();
                var user = await _userRepo.GetByIdAsync(userId);
                if (user == null) return Unauthorized();

                // 1. Check Availability (Logic hidden in Repo)
                var isAvailable = await _bookingRepo.IsBedAvailableAsync(dto.BedId, dto.DateFrom, dto.DateTo);

                if (!isAvailable)
                {
                    return Conflict(new { message = "Sorry, this bed was just booked by someone else." });
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
                    Remarks = string.Empty,
                    CreatedBy = userId,
                    CreatedDate = DateTime.UtcNow
                };

                // 2. Save using Repo
                await _bookingRepo.AddAsync(booking);

                // 3. Send Email
                try
                {
                    var adminEmail = _config["AdminEmail"];
                    // Fetch details for email
                    var gh = await _guestHouseRepo.GetByIdAsync(dto.GuestHouseId);
                    var room = await _roomRepo.GetByIdAsync(dto.RoomId);
                    var bed = await _bedRepo.GetByIdAsync(dto.BedId);

                    if (!string.IsNullOrEmpty(adminEmail) && gh != null && room != null && bed != null)
                    {
                        string emailBody = EmailTemplates.NewBookingNotification(
                            booking.BookingId, user.UserName, gh.Name, room.RoomName, bed.BedNumber, booking.DateFrom, booking.DateTo
                        );
                        await _emailService.SendEmailAsync(adminEmail, "New Booking Request Submitted", emailBody);
                    }
                }
                catch (Exception emailEx)
                {
                    Console.WriteLine($"Email failed: {emailEx.Message}");
                }

                return Ok(new { message = "Booking request submitted. Pending approval." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", details = ex.Message });
            }
        }



        [HttpGet("my-bookings")]
        [Authorize(Roles = "User")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetMyBookings()
        {
            var userId = _userResolver.GetUserId();
            var bookings = await _bookingRepo.GetUserBookingsAsync(userId);

            return Ok(bookings.Select(b => new BookingDto
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
            }));
        }



        [HttpGet("all")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAllBookings()
        {
            var bookings = await _bookingRepo.GetAllActiveAsync();

            return Ok(bookings.Select(b => new BookingDto
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
            }));
        }

        [HttpPut("approve/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ApproveBooking(int id)
        {
            // Use Repo to get details (includes User)
            var booking = await _bookingRepo.GetByIdWithDetailsAsync(id);
            if (booking == null) return NotFound();

            // Check Availability ignoring THIS booking ID
            var isAvailable = await _bookingRepo.IsBedAvailableAsync(booking.BedId, booking.DateFrom, booking.DateTo, booking.BookingId);

            if (!isAvailable)
            {
                // Auto-reject
                booking.Status = "Rejected";
                booking.Remarks = "Auto-rejected due to conflict.";
                booking.ModifiedBy = _userResolver.GetUserId();
                booking.ModifiedDate = DateTime.UtcNow;

                await _bookingRepo.UpdateAsync(booking); // Save rejection

                // Send Rejection Email
                try
                {
                    await _emailService.SendEmailAsync(booking.User.Email, "Booking Rejected", "Your booking was auto-rejected due to a conflict.");
                }
                catch { }

                return Conflict(new { message = "Booking auto-rejected due to conflict." });
            }

            // Approve
            booking.Status = "Approved";
            booking.ModifiedBy = _userResolver.GetUserId();
            booking.ModifiedDate = DateTime.UtcNow;

            await _bookingRepo.UpdateAsync(booking); // Save approval

            // Send Email
            try
            {
                string emailBody = $"Your booking #{booking.BookingId} has been APPROVED!";
                await _emailService.SendEmailAsync(booking.User.Email, "Booking Approved", emailBody);
            }
            catch (Exception ex) { Console.WriteLine("Email failed: " + ex.Message); }

            await _auditLog.LogAction("Approve Booking", booking.ModifiedBy.Value, $"Booking {booking.BookingId} Approved", "Pending");

            return Ok(new { message = "Booking approved." });
        }


        [HttpPut("reject/{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RejectBooking(int id, [FromBody] BookingRejectDto dto)
        {
            var booking = await _bookingRepo.GetByIdWithDetailsAsync(id);
            if (booking == null) return NotFound();

            booking.Status = "Rejected";
            booking.Remarks = dto.Remarks;
            booking.ModifiedBy = _userResolver.GetUserId();
            booking.ModifiedDate = DateTime.UtcNow;

            await _bookingRepo.UpdateAsync(booking);

            try
            {
                await _emailService.SendEmailAsync(booking.User.Email, "Booking Rejected", $"Rejected. Reason: {dto.Remarks}");
            }
            catch (Exception ex) { Console.WriteLine("Email failed: " + ex.Message); }

            await _auditLog.LogAction("Reject Booking", booking.ModifiedBy.Value, $"Booking {booking.BookingId} Rejected", "Pending");

            return Ok(new { message = "Booking rejected." });
        }

    }
}
