using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using GuestHouseBooking.Repositories.Interfaces;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GuestHouseController : ControllerBase
    {
        private readonly IGuestHouseRepository _guestHouseRepo;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLogService;

        public GuestHouseController(IGuestHouseRepository guestHouseRepo, UserResolverService userResolver, IAuditLogService auditLogService)
        {
            _guestHouseRepo = guestHouseRepo;
            _userResolver = userResolver;
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestHouseDto>>> GetGuestHouses()
        {
            var guestHouses = await _guestHouseRepo.GetAllActiveAsync();

            var dtos = guestHouses.Select(g => new GuestHouseDto
            {
                GuestHouseId = g.GuestHouseId,
                Name = g.Name,
                Location = g.Location,
                Description = g.Description,
                ImageUrl = g.ImageUrl
            });

            return Ok(dtos);
        }

        [HttpPost]
        public async Task<ActionResult<GuestHouseDto>> CreateGuestHouse([FromBody] GuestHouseCreateDto dto)
        {
            try
            {
                var currentUserId = _userResolver.GetUserId();

                var guestHouse = new GuestHouse
                {
                    Name = dto.Name,
                    Location = dto.Location,
                    Description = dto.Description,
                    ImageUrl = dto.ImageUrl,
                    CreatedBy = currentUserId,
                    CreatedDate = DateTime.UtcNow
                };

                // Use Repository Add
                await _guestHouseRepo.AddAsync(guestHouse);

                await _auditLogService.LogAction("GuestHouse Created", currentUserId, $"New GH: {guestHouse.Name}, ID: {guestHouse.GuestHouseId}");

                var resultDto = new GuestHouseDto
                {
                    GuestHouseId = guestHouse.GuestHouseId,
                    Name = guestHouse.Name,
                    Location = guestHouse.Location,
                    Description = guestHouse.Description,
                    ImageUrl = guestHouse.ImageUrl
                };

                return CreatedAtAction(nameof(GetGuestHouse), new { id = guestHouse.GuestHouseId }, resultDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Error", details = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestHouseDto>> GetGuestHouse(int id)
        {
            var g = await _guestHouseRepo.GetByIdAsync(id);

            if (g == null || g.Deleted) return NotFound();

            var dto = new GuestHouseDto
            {
                GuestHouseId = g.GuestHouseId,
                Name = g.Name,
                Location = g.Location,
                Description = g.Description,
                ImageUrl = g.ImageUrl
            };

            return Ok(dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuestHouse(int id, [FromBody] GuestHouseCreateDto dto)
        {
            var guestHouse = await _guestHouseRepo.GetByIdAsync(id);

            if (guestHouse == null || guestHouse.Deleted) return NotFound();

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"Name: {guestHouse.Name}";

            guestHouse.Name = dto.Name;
            guestHouse.Location = dto.Location;
            guestHouse.Description = dto.Description;
            guestHouse.ImageUrl = dto.ImageUrl;
            guestHouse.ModifiedBy = currentUserId;
            guestHouse.ModifiedDate = DateTime.UtcNow;

            // Use Repository Update
            await _guestHouseRepo.UpdateAsync(guestHouse);

            await _auditLogService.LogAction("Update GuestHouse", currentUserId, $"Name: {dto.Name}", oldVal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestHouse(int id)
        {
            var guestHouse = await _guestHouseRepo.GetByIdAsync(id);
            if (guestHouse == null || guestHouse.Deleted) return NotFound();

            var currentUserId = _userResolver.GetUserId();

            // Use Repository Soft Delete
            await _guestHouseRepo.SoftDeleteAsync(id, currentUserId);

            await _auditLogService.LogAction("Soft Delete GuestHouse", currentUserId, $"GH ID: {id} marked as deleted.");

            return NoContent();
        }
    }
}
