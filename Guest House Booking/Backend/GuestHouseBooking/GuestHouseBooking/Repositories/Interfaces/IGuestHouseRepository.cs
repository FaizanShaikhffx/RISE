using GuestHouseBooking.Models;

namespace GuestHouseBooking.Repositories.Interfaces
{
    public interface IGuestHouseRepository : IGenericRepository<GuestHouse>
    {
        Task<IEnumerable<GuestHouse>> GetAllActiveAsync(); // Custom method for soft delete
        Task SoftDeleteAsync(int id, int deletedBy);       // Custom method for soft delete
    }
}
