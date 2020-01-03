using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project_Starlord.Data;
using Project_Starlord.Models;

namespace Project_Starlord.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PinPointController : ControllerBase
    {
        private readonly MyDbContext _context;

        public PinPointController(MyDbContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetPinPoints/{tripId}")]
        public async Task<ActionResult<string>> GetPinPoints(int tripId)
        {
            var pinPoints = _context.PinPoints.Where(x => x.TripId == tripId).ToList();

            pinPoints.Select(x => { x.Latitude /= 1000000000000; return x; }).ToList();
            pinPoints.Select(x => { x.Longitude /= 1000000000000; return x; }).ToList();

            return JsonConvert.SerializeObject(pinPoints);
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

        [AllowAnonymous]
        [HttpPost]
        [Route("DeletePinPoints")]
        public async Task<ActionResult<PinPointModel>> DeletePinPoints(PinPointModel pinPoint)
        {
            _context.PinPoints.Remove(pinPoint);

            await _context.SaveChangesAsync();

            return pinPoint;
        }
    }
}