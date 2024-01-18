using Mgmt1.Models;
using Microsoft.EntityFrameworkCore;

namespace Mgmt1.Services
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Room> Rooms { get; set; }
    }
}
