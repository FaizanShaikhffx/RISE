using GuestHouseBooking.Data;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Repositories.Implementations
{
    public class GuestHouseRepository : GenericRepository<GuestHouse>, IGuestHouseRepository
    {
        public GuestHouseRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Override the generic GetAll to filter out deleted items
        public async Task<IEnumerable<GuestHouse>> GetAllActiveAsync()
        {
            return await _context.GuestHouses
                .Where(g => !g.Deleted)
                .ToListAsync();
        }

        public async Task SoftDeleteAsync(int id, int deletedBy)
        {
            var guestHouse = await _context.GuestHouses.FindAsync(id);
            if (guestHouse != null)
            {
                guestHouse.Deleted = true;
                guestHouse.DeletedBy = deletedBy;
                guestHouse.DeletedDate = DateTime.UtcNow;

                _context.Entry(guestHouse).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }
    }
}
