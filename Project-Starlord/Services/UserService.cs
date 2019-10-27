using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
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
        private List<UserModel> _users = new List<UserModel>
        {
            //todo: remove test user
            new UserModel
            {
                Id = 0, Username = "David Hasselhof", Email = "test@wanderer.app",
                Password = "Geheim123!"
            }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public UserModel Authenticate(string username, string password)
        {
            var user =
                _users.SingleOrDefault(x => x.Username == username && x.Password == password);

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

            return user.WithoutPassword();
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _users.WithoutPasswords();
        }
    }
}