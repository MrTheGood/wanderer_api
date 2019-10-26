using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project_Starlord.Data;
using Project_Starlord.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        // POST api/<controller>
        [HttpPost]
        [Route("login")]
        public bool PostLogin(UserModel user)
        {
            _context. 

            return user.Username == "ADMIN";
        }
    }
}
