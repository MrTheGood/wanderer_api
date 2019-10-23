using System.Data.Entity.Infrastructure;
using Project_Starlord.Models;

namespace Project_Starlord
{
    public interface IDbContext
    {
        Microsoft.EntityFrameworkCore.DbSet<UserModel> Users { get; set; }
        DbContextConfiguration Configuration { get; }
        int SaveChanges();
        int CurrentUserId { get; set; }
    }
}
