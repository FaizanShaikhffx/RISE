using GuestHouseBooking.Data;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Repositories.Implementations
{
    public class RoomRepository : GenericRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Room>> GetAllActiveAsync()
        {
            return await _context.Rooms.Where(r => !r.Deleted).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetRoomsByGuestHouseAsync(int guestHouseId)
        {
            return await _context.Rooms
                .Where(r => r.GuestHouseId == guestHouseId && !r.Deleted)
                .ToListAsync();
        }
    }
}
