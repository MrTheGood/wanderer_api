using Microsoft.EntityFrameworkCore;
using Project_Starlord.Models;

namespace Project_Starlord.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        public DbSet<UserModel> Users { get; set; }
        public DbSet<TripModel> Trips { get; set; }
        public DbSet<PinPointModel> PinPoints { get; set; }
    }
}
