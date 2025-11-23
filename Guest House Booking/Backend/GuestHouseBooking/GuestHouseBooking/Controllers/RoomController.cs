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
    public class RoomController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLog;

        public RoomController(ApplicationDbContext context, UserResolverService userResolver, IAuditLogService auditLog)
        {
            _context = context;
            _userResolver = userResolver;
            _auditLog = auditLog;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            return await _context.Rooms
                .Where(r => !r.Deleted) 
                .Select(r => new RoomDto 
                {
                    RoomId = r.RoomId,
                    GuestHouseId = r.GuestHouseId,
                    RoomName = r.RoomName,
                    GenderAllowed = r.GenderAllowed
                })
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _context.Rooms
                .Where(r => r.RoomId == id && !r.Deleted)
                .Select(r => new RoomDto
                {
                    RoomId = r.RoomId,
                    GuestHouseId = r.GuestHouseId,
                    RoomName = r.RoomName,
                    GenderAllowed = r.GenderAllowed
                })
                .FirstOrDefaultAsync();

            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        [HttpPost]
        public async Task<ActionResult<RoomDto>> CreateRoom([FromBody] RoomCreateDto dto)
        {
            var currentUserId = _userResolver.GetUserId();

            var room = new Room
            {
                GuestHouseId = dto.GuestHouseId,
                RoomName = dto.RoomName,
                GenderAllowed = dto.GenderAllowed,
                CreatedBy = currentUserId,
                CreatedDate = DateTime.UtcNow
            };

            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();

            await _auditLog.LogAction("Create Room", currentUserId, $"New Room: {room.RoomName}", null);

            var resultDto = new RoomDto
            {
                RoomId = room.RoomId,
                GuestHouseId = room.GuestHouseId,
                RoomName = room.RoomName,
                GenderAllowed = room.GenderAllowed
            };

            return CreatedAtAction(nameof(GetRoom), new { id = room.RoomId }, resultDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomCreateDto dto)
        {
            var room = await _context.Rooms.FindAsync(id);

            if (room == null || room.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"Name: {room.RoomName}, Gender: {room.GenderAllowed}";

            room.GuestHouseId = dto.GuestHouseId;
            room.RoomName = dto.RoomName;
            room.GenderAllowed = dto.GenderAllowed;
            room.ModifiedBy = currentUserId;
            room.ModifiedDate = DateTime.UtcNow;

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            string newVal = $"Name: {dto.RoomName}, Gender: {dto.GenderAllowed}";
            await _auditLog.LogAction("Update Room", currentUserId, newVal, oldVal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room == null || room.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();

         
            room.Deleted = true;
            room.DeletedBy = currentUserId;
            room.DeletedDate = DateTime.UtcNow;

            _context.Entry(room).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _auditLog.LogAction("Soft Delete Room", currentUserId, $"RoomID: {id} marked as deleted", null);

            return NoContent(); // Success
        }
    }
}
