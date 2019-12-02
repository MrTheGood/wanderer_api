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
    public class PinPointController : ControllerBase
    {
        private readonly MyDbContext _context;

        [AllowAnonymous]
        [HttpPost]
        [Route("GetPinPoints")]
        public async Task<ActionResult<List<PinPointModel>>> GetPinPoints(int tripId)
        {
            var pinPoints = _context.PinPoints.Where(x => x.TripId == tripId);

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