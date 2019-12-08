using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_Starlord.Data;
using Project_Starlord.Models;

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TripController(MyDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult<TripModel>> PostTripModel(TripModel trip)
        {
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return trip;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<TripModel>> DeleteUserModel(int id)
        {
            var tripModel = await _context.Trips.FindAsync(id);
            if (tripModel == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(tripModel);
            await _context.SaveChangesAsync();

            return tripModel;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetTrips/{userId}")]
        public async Task<ActionResult<string>> GetTrips(int userId)
        {
            var trips = _context.Trips.Where(x => x.UserId == userId);

            if (!trips.Any())
            {
                return BadRequest();
            }

            return JsonConvert.SerializeObject(trips.ToList());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetFollowerTrips/{userId}")]
        public async Task<ActionResult<string>> GetFollowerTrips(int userId)
        {
            var followers = _context.Followers.Where(x => x.FollowerId == userId).Select(x => x.FollowedId);

            if (followers == null)
            {
                return BadRequest();
            }

            var trips = _context.Trips.Where(x => followers.Contains(x.UserId));

            if (!trips.Any())
            {
                return BadRequest();
            }

            return JsonConvert.SerializeObject(trips);
        }
    }
}