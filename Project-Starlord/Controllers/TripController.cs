using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project_Starlord.Data;
using Project_Starlord.Models;

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly MyDbContext _context;

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
        [Route("GetTrips")]
        public async Task<ActionResult<List<TripModel>>> GetTrips(int userId)
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

            return trips.ToList();
        }
    }
}