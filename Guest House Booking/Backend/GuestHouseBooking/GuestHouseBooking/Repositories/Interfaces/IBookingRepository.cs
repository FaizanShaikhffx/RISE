using GuestHouseBooking.Models;

namespace GuestHouseBooking.Repositories.Interfaces
{
    public interface IBookingRepository : IGenericRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetAllActiveAsync(); // Admin view
        Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId); // User view
        Task<Booking?> GetByIdWithDetailsAsync(int id); // For emails (includes User)

        // The complex availability check
        Task<bool> IsBedAvailableAsync(int bedId, DateTime from, DateTime to, int? excludeBookingId = null);

        // For the bed selection dropdown logic
        Task<IEnumerable<int>> GetBookedBedIdsAsync(int roomId, DateTime from, DateTime to);
    }
}
