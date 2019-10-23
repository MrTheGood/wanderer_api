using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Project_Starlord.Models;

namespace Project_Starlord.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext()
        {

        }
        DbSet<UserModel> Users { get; set; }
    }
}
