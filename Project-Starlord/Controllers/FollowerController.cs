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
    public class FollowerController : ControllerBase
    {
        private readonly MyDbContext _context;

        public FollowerController(MyDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("PostFollower/{userToken}/{followId}")]
        public async Task<ActionResult<FollowerModel>> PostFollower(string userToken, int followedId)
        {
            int userId = _context.Users.Where(x => x.Token == userToken).Select(x => x.Id).FirstOrDefault();

            if (userId == 0)
            {
                return BadRequest();
            }

            FollowerModel follower = new FollowerModel
            {
                FollowerId = userId,
                FollowedId = followedId
            };

            _context.Followers.Add(follower);
            await _context.SaveChangesAsync();

            return follower;
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<FollowerModel>> DeleteFollowerModel(int id)
        {
            var followerModel = await _context.Followers.FindAsync(id);
            if (followerModel == null)
            {
                return NotFound();
            }

            _context.Followers.Remove(followerModel);
            await _context.SaveChangesAsync();

            return followerModel;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("GetFollowers/{userId}")]
        public async Task<ActionResult<string>> GetFollowers(int userId)
        {
            var followers = _context.Followers.Where(x => x.FollowerId == userId);

            if (!followers.Any())
            {
                return BadRequest();
            }

            return JsonConvert.SerializeObject(followers.ToList());
        }
    }
}