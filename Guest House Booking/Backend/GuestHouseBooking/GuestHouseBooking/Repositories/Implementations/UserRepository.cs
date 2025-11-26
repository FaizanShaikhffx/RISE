using GuestHouseBooking.Data;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email && !u.Deleted);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users.AnyAsync(u => u.Email == email);
        }
    }
}
