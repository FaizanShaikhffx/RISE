using GuestHouseBooking.Data;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Repositories.Implementations
{
    public class BedRepository : GenericRepository<Bed>, IBedRepository
    {
        public BedRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Bed>> GetAllActiveAsync()
        {
            return await _context.Beds.Where(b => !b.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<Bed>> GetBedsByRoomAsync(int roomId)
        {
            return await _context.Beds
                .Where(b => b.RoomId == roomId && !b.Deleted)
                .ToListAsync();
        }
    }
}
