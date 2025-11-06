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
    [Authorize(Roles = "Admin")]
    public class BedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLog;

        public BedController(ApplicationDbContext context, UserResolverService userResolver, IAuditLogService auditLog)
        {
            _context = context;
            _userResolver = userResolver;
            _auditLog = auditLog;
        }

        // GET: api/bed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetBeds()
        {
            return await _context.Beds
                .Where(b => !b.Deleted) // <-- Filters out soft-deleted items
                .Select(b => new BedDto // <-- Maps to DTO
                {
                    BedId = b.BedId,
                    RoomId = b.RoomId,
                    BedNumber = b.BedNumber
                })
                .ToListAsync();
        }

        // GET: api/bed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BedDto>> GetBed(int id)
        {
            var bed = await _context.Beds
                .Where(b => b.BedId == id && !b.Deleted)
                .Select(b => new BedDto
                {
                    BedId = b.BedId,
                    RoomId = b.RoomId,
                    BedNumber = b.BedNumber
                })
                .FirstOrDefaultAsync();

            if (bed == null)
            {
                return NotFound();
            }

            return Ok(bed);
        }

        // GET: api/bed/by-room/5
        // A helper to get all beds for a specific room
        [HttpGet("by-room/{roomId}")]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetBedsByRoom(int roomId)
        {
            return await _context.Beds
                .Where(b => b.RoomId == roomId && !b.Deleted)
                .Select(b => new BedDto
                {
                    BedId = b.BedId,
                    RoomId = b.RoomId,
                    BedNumber = b.BedNumber
                })
                .ToListAsync();
        }

        // POST: api/bed
        [HttpPost]
        public async Task<ActionResult<BedDto>> CreateBed([FromBody] BedCreateDto dto)
        {
            var currentUserId = _userResolver.GetUserId();

            var bed = new Bed
            {
                RoomId = dto.RoomId,
                BedNumber = dto.BedNumber,
                // We set 'CreatedBy' here, but it's not in the Bed model.
                // You can add it if you want, or just omit it.
                // Let's assume the Bed model doesn't need audit fields for simplicity.
            };

            _context.Beds.Add(bed);
            await _context.SaveChangesAsync();

            await _auditLog.LogAction("Create Bed", currentUserId, $"New Bed: {bed.BedNumber} in RoomID: {bed.RoomId}", null);

            var resultDto = new BedDto
            {
                BedId = bed.BedId,
                RoomId = bed.RoomId,
                BedNumber = bed.BedNumber
            };

            return CreatedAtAction(nameof(GetBed), new { id = bed.BedId }, resultDto);
        }

        // PUT: api/bed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBed(int id, [FromBody] BedCreateDto dto)
        {
            var bed = await _context.Beds.FindAsync(id);

            if (bed == null || bed.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"BedNumber: {bed.BedNumber}, RoomID: {bed.RoomId}";

            bed.RoomId = dto.RoomId;
            bed.BedNumber = dto.BedNumber;

            _context.Entry(bed).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            string newVal = $"BedNumber: {dto.BedNumber}, RoomID: {dto.RoomId}";
            await _auditLog.LogAction("Update Bed", currentUserId, newVal, oldVal);

            return NoContent(); // Success
        }

        // DELETE: api/bed/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(int id)
        {
            var bed = await _context.Beds.FindAsync(id);
            if (bed == null || bed.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();

            // --- SOFT DELETE ---
            bed.Deleted = true;
            // Add DeletedBy/DeletedDate fields to your Bed model
            // if you want to track this, just like in GuestHouse/Room.
            // e.g., bed.DeletedBy = currentUserId;

            _context.Entry(bed).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _auditLog.LogAction("Soft Delete Bed", currentUserId, $"BedID: {id} marked as deleted", null);

            return NoContent(); // Success
        }
    }
}
