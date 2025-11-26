using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces; // Import
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
        private readonly IBedRepository _bedRepo;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLog;

        public BedController(IBedRepository bedRepo, UserResolverService userResolver, IAuditLogService auditLog)
        {
            _bedRepo = bedRepo; // Inject
            _userResolver = userResolver;
            _auditLog = auditLog;
        }

        // GET: api/bed
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetBeds()
        {
            var beds = await _bedRepo.GetAllActiveAsync();

            var dtos = beds.Select(b => new BedDto
            {
                BedId = b.BedId,
                RoomId = b.RoomId,
                BedNumber = b.BedNumber
            });

            return Ok(dtos);
        }

        // GET: api/bed/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BedDto>> GetBed(int id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);

            if (bed == null || bed.Deleted)
            {
                return NotFound();
            }

            var dto = new BedDto
            {
                BedId = bed.BedId,
                RoomId = bed.RoomId,
                BedNumber = bed.BedNumber
            };

            return Ok(dto);
        }

        // GET: api/bed/by-room/5
        // A helper to get all beds for a specific room
        [HttpGet("by-room/{roomId}")]
        public async Task<ActionResult<IEnumerable<BedDto>>> GetBedsByRoom(int roomId)
        {
            var beds = await _bedRepo.GetBedsByRoomAsync(roomId);

            var dtos = beds.Select(b => new BedDto
            {
                BedId = b.BedId,
                RoomId = b.RoomId,
                BedNumber = b.BedNumber
            });

            return Ok(dtos);
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
                // Bed model usually doesn't have CreatedBy based on your initial models, 
                // but if you added it, set it here.
            };

            await _bedRepo.AddAsync(bed);

            await _auditLog.LogAction("Create Bed", currentUserId, $"New Bed: {bed.BedNumber} in RoomID: {bed.RoomId}", null);

            var resultDto = new BedDto
            {
                BedId = bed.BedId,
                RoomId = bed.RoomId,
                BedNumber = bed.BedNumber
            };

            return CreatedAtAction(nameof(GetBed), new { id = bed.BedId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBed(int id, [FromBody] BedCreateDto dto)
        {
            var bed = await _bedRepo.GetByIdAsync(id);

            if (bed == null || bed.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"BedNumber: {bed.BedNumber}, RoomID: {bed.RoomId}";

            bed.RoomId = dto.RoomId;
            bed.BedNumber = dto.BedNumber;

            await _bedRepo.UpdateAsync(bed);

            string newVal = $"BedNumber: {dto.BedNumber}, RoomID: {dto.RoomId}";
            await _auditLog.LogAction("Update Bed", currentUserId, newVal, oldVal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBed(int id)
        {
            var bed = await _bedRepo.GetByIdAsync(id);
            if (bed == null || bed.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();

            // Soft Delete
            bed.Deleted = true;
            await _bedRepo.UpdateAsync(bed);

            await _auditLog.LogAction("Soft Delete Bed", currentUserId, $"BedID: {id} marked as deleted", null);

            return NoContent();
        }
    }
}
