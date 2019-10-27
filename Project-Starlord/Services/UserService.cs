using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Project_Starlord.Data;
using Project_Starlord.Helpers;
using Project_Starlord.Models;

namespace Project_Starlord.Services
{
    public interface IUserService
    {
        UserModel Authenticate(string username, string password);
        IEnumerable<UserModel> GetAll();
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly MyDbContext _context;

        public UserService(IOptions<AppSettings> appSettings, MyDbContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user =
                _context.Users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                    {new Claim(ClaimTypes.Name, user.Id.ToString())}
                ),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            _context.SaveChanges();

            return user.WithoutPassword();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _context.Users.WithoutPasswords();
        }
    }
}