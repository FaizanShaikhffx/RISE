using GuestHouseBooking.Models;

namespace GuestHouseBooking.Repositories.Interfaces
{
    public interface IBedRepository : IGenericRepository<Bed>
    {
        Task<IEnumerable<Bed>> GetAllActiveAsync();
        Task<IEnumerable<Bed>> GetBedsByRoomAsync(int roomId);
    }
}
