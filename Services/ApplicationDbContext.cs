using Mgmt1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Mgmt1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; } // Modificare aici

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurația cheii primare pentru entitatea Booking
            modelBuilder.Entity<Booking>().HasKey(b => b.BookingId); 

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
