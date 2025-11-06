using GuestHouseBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace GuestHouseBooking.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<GuestHouse> GuestHouses { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<EmailNotificationLog> EmailNotificationLogs { get; set; }
        public DbSet<PasswordResetOtp> PasswordResetOtps { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Room)
                .WithMany() 
                .HasForeignKey(b => b.RoomId)
                .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.GuestHouse)
                .WithMany() 
                .HasForeignKey(b => b.GuestHouseId)
                .OnDelete(DeleteBehavior.NoAction);

        }


    }
}
