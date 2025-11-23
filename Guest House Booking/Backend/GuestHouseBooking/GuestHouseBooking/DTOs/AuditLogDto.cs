namespace GuestHouseBooking.DTOs
{
    public class AuditLogDto
    {
        public int AuditLogId { get; set; }
        public string Action { get; set; }
        public string UserName { get; set; } 
        public DateTime Timestamp { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
}
