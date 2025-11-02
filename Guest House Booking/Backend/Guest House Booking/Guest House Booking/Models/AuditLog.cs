using System;

namespace Guest_House_Booking.Models

{
    public class AuditLog
    {
        public Guid Id { get; set; }
        public string Action { get; set; } 
        public string EntityType { get; set; } 
        public string EntityId { get; set; }

        public DateTime Timestamp { get; set; }
        public string UserId { get; set; } 
        public virtual ApplicationUser User { get; set; }
    }
}
