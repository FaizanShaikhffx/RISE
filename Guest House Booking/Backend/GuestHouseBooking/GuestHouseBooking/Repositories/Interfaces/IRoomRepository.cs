using GuestHouseBooking.Models;

namespace GuestHouseBooking.Repositories.Interfaces
{
    public interface IRoomRepository : IGenericRepository<Room>
    {
        Task<IEnumerable<Room>> GetAllActiveAsync();
        Task<IEnumerable<Room>> GetRoomsByGuestHouseAsync(int guestHouseId);
    }
}
