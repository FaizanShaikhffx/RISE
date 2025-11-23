using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using GuestHouseBooking.Models;
using GuestHouseBooking.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class GuestHouseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserResolverService _userResolver;
        private readonly IAuditLogService _auditLogService;

        public GuestHouseController(ApplicationDbContext context, UserResolverService userResolver, IAuditLogService auditLogService)
        {
            _context = context;
            _userResolver = userResolver;
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GuestHouseDto>>> GetGuestHouses()
        {
            return await _context.GuestHouses
                .Where(g => !g.Deleted)
                .Select(g => new GuestHouseDto
                {
                    GuestHouseId = g.GuestHouseId,
                    Name = g.Name,
                    Location = g.Location,
                    Description = g.Description,
                    ImageUrl = g.ImageUrl
                }).ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<GuestHouseDto>> CreateGuestHouse([FromBody] GuestHouseCreateDto dto)
        {
            try {
                var currentUserId = _userResolver.GetUserId();

                if (currentUserId == 0)
                {
                    return BadRequest(new { message = "Could not resolve user ID from token." });
                }

                var guestHouse = new GuestHouse
                {
                    Name = dto.Name,
                    Location = dto.Location,
                    Description = dto.Description,
                    ImageUrl = dto.ImageUrl,
                    CreatedBy = currentUserId,
                    CreatedDate = DateTime.UtcNow
                };

                _context.GuestHouses.Add(guestHouse);
                await _context.SaveChangesAsync();

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
                Console.WriteLine(ex.ToString());
                return StatusCode(500, new
                {
                    message = "An internal server error occurred.",
                    details = ex.Message,
                    innerException = ex.InnerException?.Message 
                });
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GuestHouseDto>> GetGuestHouse(int id)
        {
            var guestHouse = await _context.GuestHouses
                .Where(g => g.GuestHouseId == id && !g.Deleted)
                .Select(g => new GuestHouseDto
                {
                    GuestHouseId = g.GuestHouseId,
                    Name = g.Name,
                    Location = g.Location,
                    Description = g.Description
                })
                .FirstOrDefaultAsync();

            if (guestHouse == null)
            {
                return NotFound();
            }

            return Ok(guestHouse);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGuestHouse(int id, [FromBody] GuestHouseCreateDto dto)
        {
            var guestHouse = await _context.GuestHouses.FindAsync(id);

            if (guestHouse == null || guestHouse.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();
            string oldVal = $"Name: {guestHouse.Name}, Location: {guestHouse.Location}";

            guestHouse.Name = dto.Name;
            guestHouse.Location = dto.Location;
            guestHouse.Description = dto.Description;
            guestHouse.ImageUrl = dto.ImageUrl;
            guestHouse.ModifiedBy = currentUserId;
            guestHouse.ModifiedDate = DateTime.UtcNow;

            _context.Entry(guestHouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            string newVal = $"Name: {dto.Name}, Location: {dto.Location}";
            await _auditLogService.LogAction("Update GuestHouse", currentUserId, newVal, oldVal);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestHouse(int id)
        {
            var guestHouse = await _context.GuestHouses.FindAsync(id);
            if (guestHouse == null || guestHouse.Deleted)
            {
                return NotFound();
            }

            var currentUserId = _userResolver.GetUserId();

            guestHouse.Deleted = true;
            guestHouse.DeletedBy = currentUserId;
            guestHouse.DeletedDate = DateTime.UtcNow;

            _context.Entry(guestHouse).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            await _auditLogService.LogAction("Soft Delete GuestHouse", currentUserId, $"GH ID: {id} marked as deleted.");

            return NoContent();
        }
    }
}
