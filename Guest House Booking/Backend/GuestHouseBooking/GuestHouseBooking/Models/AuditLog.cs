using System.ComponentModel.DataAnnotations;

namespace GuestHouseBooking.Models
{
    public class AuditLog
    {
        public int AuditLogId { get; set; }

        [Required]
        public string Action { get; set; } 

        public int? UserId { get; set; }
        public User User { get; set; }

        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
