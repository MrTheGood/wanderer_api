using Project_Starlord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Project_Starlord.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() { }

        public DbSet<UserModel> Users { get; set; }
    }
}
