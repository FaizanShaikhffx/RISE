using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GuestHouseBooking.Repositories.Interfaces;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepo;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLog;

        public RoomController(IRoomRepository roomRepo, UserResolverService userResolver, IAuditLogService auditLog)
        {
            _roomRepo = roomRepo;
            _userResolver = userResolver;
            _auditLog = auditLog;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoomDto>>> GetRooms()
        {
            var rooms = await _roomRepo.GetAllActiveAsync();

            var dtos = rooms.Select(r => new RoomDto
            {
                RoomId = r.RoomId,
                GuestHouseId = r.GuestHouseId,
                RoomName = r.RoomName,
                GenderAllowed = r.GenderAllowed
            });

            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDto>> GetRoom(int id)
        {
            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null || room.Deleted)
            {
                return NotFound();
            }

            var dto = new RoomDto
            {
                RoomId = room.RoomId,
                GuestHouseId = room.GuestHouseId,
                RoomName = room.RoomName,
                GenderAllowed = room.GenderAllowed
            };

            return Ok(dto);
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

            // Use Repository Add
            await _roomRepo.AddAsync(room);

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
            var room = await _roomRepo.GetByIdAsync(id);

            if (room == null || room.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"Name: {room.RoomName}, Gender: {room.GenderAllowed}";

            // Modify the entity
            room.GuestHouseId = dto.GuestHouseId;
            room.RoomName = dto.RoomName;
            room.GenderAllowed = dto.GenderAllowed;
            room.ModifiedBy = currentUserId;
            room.ModifiedDate = DateTime.UtcNow;

            // Use Repository Update
            await _roomRepo.UpdateAsync(room);

            string newVal = $"Name: {dto.RoomName}, Gender: {dto.GenderAllowed}";
            await _auditLog.LogAction("Update Room", currentUserId, newVal, oldVal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var room = await _roomRepo.GetByIdAsync(id);
            if (room == null || room.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();

            // Soft Delete Logic: Mark as deleted, then Update
            room.Deleted = true;
            room.DeletedBy = currentUserId;
            room.DeletedDate = DateTime.UtcNow;

            await _roomRepo.UpdateAsync(room);

            await _auditLog.LogAction("Soft Delete Room", currentUserId, $"RoomID: {id} marked as deleted", null);

            return NoContent();
        }
    }
}
