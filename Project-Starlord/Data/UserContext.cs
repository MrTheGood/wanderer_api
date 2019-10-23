using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Project_Starlord.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Project_Starlord.Data
{
    public class UserContext : DbContext, IDbContext
    {
        public UserContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options)
        {
        }

        public Microsoft.EntityFrameworkCore.DbSet<UserModel> Users { get; set; }
        public DbContextConfiguration Configuration { get; }

        public int SaveChanges()
        {
            return 0;
        }

        public int CurrentUserId { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //}
    }
}
