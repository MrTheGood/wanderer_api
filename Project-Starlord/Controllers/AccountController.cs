using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Starlord.Data;
using Project_Starlord.Models;
using Project_Starlord.Services;
using Project_Starlord.Helpers;
using Newtonsoft.Json;

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly IUserService _userService;

        public AccountController(MyDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        // GET: api/UserModels
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserModel>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/UserModels/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserModel>> GetUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);

            if (userModel == null)
            {
                return NotFound();
            }

            return userModel;
        }

        // PUT: api/UserModels/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserModel(int id, UserModel userModel)
        {
            if (id != userModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(userModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UserModels
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserModel>> PostUserModel(UserModel userModel)
        {
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserModel), new { id = userModel.Id }, userModel);
        }

        // DELETE: api/UserModels/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserModel>> DeleteUserModel(int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }

            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        // POST: api/UserModels
        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<string>> Login(UserModel userModel)
        {
            var user = _userService.Authenticate(userModel.Username, userModel.Password);

            if (user == null)
            {
                return null;
            }

            var result = new
            {
                Token = user.Token
            };

            return JsonConvert.SerializeObject(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserModel>> Register(UserModel userModel)
        {
            if (String.IsNullOrWhiteSpace(userModel.Password))
            {
                return null;
            }
            if (String.IsNullOrWhiteSpace(userModel.Username))
            {
                return null;
            }
            if (String.IsNullOrWhiteSpace(userModel.Email))
            {
                return null;
            }

            userModel.HashPassword();

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return userModel;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetPinPoints")]
        public async Task<ActionResult<List<PinPointModel>>> GetPinPoints(int userId)
        {

            var user = _context.Users.FirstOrDefault(x => x.Id == userId);

            if (user == null)
            {
                return BadRequest();
            }

            var trips = _context.Trips.Where(x => x.User == user);

            if (!trips.Any())
            {
                return BadRequest();
            }

            var pinPoints = _context.PinPoints.Where(x => trips.Contains(x.Trip));

            return pinPoints.ToList();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SavePinPoints")]
        public async Task<ActionResult<PinPointModel>> SavePinPoints(PinPointModel pinPoint)
        {
            _context.PinPoints.Add(pinPoint);

            await _context.SaveChangesAsync();

            return pinPoint;
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}