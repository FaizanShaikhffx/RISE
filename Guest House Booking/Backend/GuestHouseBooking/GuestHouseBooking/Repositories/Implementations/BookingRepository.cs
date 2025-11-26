using GuestHouseBooking.Data;
using GuestHouseBooking.Models;
using GuestHouseBooking.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Repositories.Implementations
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<Booking>> GetAllActiveAsync()
        {
            return await _context.Bookings
                .Where(b => !b.Deleted)
                .Include(b => b.User)
                .Include(b => b.GuestHouse)
                .Include(b => b.Room)
                .Include(b => b.Bed)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(int userId)
        {
            return await _context.Bookings
                .Where(b => b.UserId == userId && !b.Deleted)
                .Include(b => b.User)
                .Include(b => b.GuestHouse)
                .Include(b => b.Room)
                .Include(b => b.Bed)
                .OrderByDescending(b => b.CreatedDate)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.User) // Important for emails!
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<bool> IsBedAvailableAsync(int bedId, DateTime from, DateTime to, int? excludeBookingId = null)
        {
            // Using the .Date fix we implemented earlier
            return !await _context.Bookings
                .AnyAsync(b => b.BedId == bedId &&
                               (excludeBookingId == null || b.BookingId != excludeBookingId) &&
                               (b.Status == "Approved" || b.Status == "Pending") &&
                               b.DateFrom.Date < to.Date &&
                               b.DateTo.Date > from.Date);
        }

        public async Task<IEnumerable<int>> GetBookedBedIdsAsync(int roomId, DateTime from, DateTime to)
        {
            // Used for the dropdown logic
            return await _context.Bookings
                .Where(b => b.RoomId == roomId &&
                            (b.Status == "Approved" || b.Status == "Pending") &&
                            b.DateFrom.Date < to.Date &&
                            b.DateTo.Date > from.Date)
                .Select(b => b.BedId)
                .Distinct()
                .ToListAsync();
        }
    }
}
