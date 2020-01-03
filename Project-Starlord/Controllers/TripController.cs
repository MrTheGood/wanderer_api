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

        [AllowAnonymous]
        [HttpPost]
        [Route("PostTripsWithOutPinPoints")]
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
        [Route("GetFollowerTrips/{userToken}")]
        public async Task<ActionResult<string>> GetFollowerTrips(string userToken)
        {
            var userId = _context.Users.Where(x => x.Token == userToken).Select(x => x.Id).FirstOrDefault();

            if (userId == 0)
            {
                return BadRequest();
            }

            var followers = _context.Followers.Where(x => x.FollowerId == userId).Select(x => x.FollowedId);

            if (!followers.Any())
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

        [AllowAnonymous]
        [HttpPost]
        [Route("PostTrip")]
        public async Task<ActionResult<TripModel>> PostTripWithPinpoints(ReceivedInfo model)
        {
            var user = _context.Users.FirstOrDefault(x => x.Token == model.Token);

            if (user == null)
            {
                return NotFound("No user found with token!");
            }

            var trip = new TripModel
            {
                TimestampFrom = model.From,
                TimestampTo = model.To,
                TripName = model.Name,
                UserId = user.Id
            };

            _context.Trips.Add(trip);
            _context.SaveChanges();

            List<PinPointModel> pinpoints = new List<PinPointModel>();

            int i = 0;

            foreach (Titudes modelPinpoint in model.Pinpoints)
            {
                pinpoints.Add(new PinPointModel
                {
                    Latitude = modelPinpoint.Lat * 1000000000000000,
                    Longitude = modelPinpoint.Long * 1000000000000000,
                    Sequence = i,
                    Timestamp = DateTime.Now,
                    TripId = trip.Id
                });

                i++;
            }

            _context.PinPoints.AddRange(pinpoints);
            await _context.SaveChangesAsync();

            return null;
        }
    }

    public class ReceivedInfo
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public Titudes[] Pinpoints { get; set; }
    }

    public class Titudes
    {
        public decimal Long { get; set; }
        public decimal Lat { get; set; }
    }
}