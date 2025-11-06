namespace GuestHouseBooking.Services
{
    public interface IAuditLogService
    {
        Task LogAction(string action, int userId, string newValue, string oldValue = null);
    }
}
