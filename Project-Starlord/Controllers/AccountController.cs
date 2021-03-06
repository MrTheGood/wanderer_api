﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        [AllowAnonymous]
        [HttpGet("{id}")]
        [Route("GetUserModel/{id}/{token}")]
        public async Task<ActionResult<string>> GetUserModel(int id, string token)
        {
            var userModel = _context.Users.FirstOrDefault(x => x.Id == id);

            if (userModel == null)
            {
                return NotFound("User not found!");
            }

            var currentUser = _context.Users.Where(x => x.Token == token).FirstOrDefault();

            if (currentUser == null) {
                return NotFound("Current user not found");
            }

            var isFollowing = _context.Followers.Where(x => x.FollowedId == id && x.FollowerId == currentUser.Id).Any();

            var result = new UsermodelExtender()
            {
                Email = userModel.Email,
                Id = userModel.Id,
                IsFollowing = isFollowing,
                Token = "",
                Username = userModel.Username,
                Password = ""
            };

            return JsonConvert.SerializeObject(result);
        }

        private class UsermodelExtender : UserModel
        {
            public bool IsFollowing { get; set; } = false;
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
        [Route("login")]
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

            var emailAlreadyExists = _context.Users.Any(x => x.Email == userModel.Email);

            if (emailAlreadyExists)
            {
                return null;
            }

            userModel.HashPassword();

            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();

            return userModel.WithoutPassword();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Search/{filterValue}")]
        public async Task<ActionResult<string>> SearchUser(string filterValue)
        {
            if (filterValue == null)
            {
                filterValue = "";
            }

            var userModels = _context.Users.Where(x => x.Username.Contains(filterValue)).ToList();

            if (!userModels.Any())
            {
                return NotFound();
            }

            var result = new List<UserModel>();

            foreach (var userModel in userModels)
            {
                result.Add(userModel.WithoutPassword());
            }

            return JsonConvert.SerializeObject(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Search")]
        public async Task<ActionResult<string>> SearchUserNoInput()
        {
            return SearchUser("").Result;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("SearchFollowers/{token}")]
        public async Task<ActionResult<string>> SearchFollowers(string token)
        {
            var currentUserId = _context.Users.Where(x => x.Token == token).Select(x => x.Id).FirstOrDefault();

            if (currentUserId == 0) {
                return NotFound();
            }

            IQueryable<int> followedUserIds = _context.Followers.Where(x => x.FollowerId == currentUserId).Select(x => x.FollowedId);

            if (!followedUserIds.Any()) {
                return NotFound();
            }

            List<UserModel> followedUsers = _context.Users.Where(x => followedUserIds.Contains(x.Id)).Select(x => x.WithoutPassword()).ToList();

            return JsonConvert.SerializeObject(followedUsers);
        }

        [HttpPost]
        [Route("ForgotPassword/{email}")]
        public async Task<ActionResult<IActionResult>> ForgotPassword(string email)
        {
            if (String.IsNullOrWhiteSpace(email))
            {
                return BadRequest();
            }

            if (_context.Users.Any(e => e.Email == email))
            {
                ResetTokenModel model = new ResetTokenModel
                {
                    Email = email,
                    Expires = DateTime.UtcNow.AddHours(24),
                    IsTokenUsed = false
                };

                // Generate reset token
                byte[] resetTokenBytes;
                new RNGCryptoServiceProvider().GetBytes(resetTokenBytes = new byte[16]);
                model.Token = Convert.ToBase64String(resetTokenBytes);

                //TODO: send reset email or whatever
                string message =
                    "Hi! To reset your password you need to open the following link within 24h: \n\n https://wanderer.app/passwordReset?token=" +
                    model.Token;


                _context.ResetTokens.Add(model.HashToken());
                await _context.SaveChangesAsync();

                return Ok();
            }

            return NotFound();
        }

        //TODO Model for saver password protection
        [HttpGet]
        [Route("ResetPassword")]
        public async Task<ActionResult<UserModel>> ResetPassword(int id, string resetToken,
            string newPassword)
        {
            if (!_context.ResetTokens.Any(e => e.Id == id))
            {
                return NotFound();
            }

            ResetTokenModel tokenModel = _context.ResetTokens.First(e => e.Id == id);

            if (DateTime.Now - tokenModel.Expires > TimeSpan.Zero || tokenModel.IsTokenUsed)
            {
                throw new UnauthorizedAccessException();
            }


            byte[] hashBytes = Convert.FromBase64String(tokenModel.Token);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(resetToken, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(100);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();


            // So the token exists, is not expired or used, and matches. Time to change the password.
            if (String.IsNullOrWhiteSpace(newPassword))
            {
                return BadRequest();
            }

            UserModel user = _context.Users.First(it => it.Email == tokenModel.Email);
            user.Password = newPassword;
            user.HashPassword();
            _context.Users.Update(user);

            tokenModel.IsTokenUsed = true;
            _context.ResetTokens.Update(tokenModel);

            await _context.SaveChangesAsync();

            return user.WithoutPassword();
        }

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
