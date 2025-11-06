using GuestHouseBooking.Data;
using GuestHouseBooking.Models;

namespace GuestHouseBooking.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly ApplicationDbContext _context;

        public AuditLogService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task LogAction(string action, int userId, string newValue, string oldValue = null)
        {
            var log = new AuditLog
            {
                Action = action,
                UserId = userId,
                Timestamp = DateTime.UtcNow,
                NewValue = newValue,
                OldValue = oldValue
            };

            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}
