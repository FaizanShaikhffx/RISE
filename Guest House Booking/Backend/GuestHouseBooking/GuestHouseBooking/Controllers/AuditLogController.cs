using GuestHouseBooking.Data;
using GuestHouseBooking.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")] 
    public class AuditLogController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuditLogController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/AuditLog
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuditLogDto>>> GetAuditLogs()
        {
            return await _context.AuditLogs
                .Include(log => log.User) 
                .OrderByDescending(log => log.Timestamp)
                .Select(log => new AuditLogDto
                {
                    AuditLogId = log.AuditLogId,
                    Action = log.Action,
                   
                    UserName = log.User != null ? log.User.UserName : "System",
                    Timestamp = log.Timestamp,
                    OldValue = log.OldValue,
                    NewValue = log.NewValue
                })
                .ToListAsync();
        }
    }
}
