using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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
                _context.Users.SingleOrDefault(x => x.Username == username);

            if (user == null)
                return null;

            byte[] hashBytes = Convert.FromBase64String(user.Password);
            /* Get the salt */
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            /* Compute the hash on the password the user entered */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(100);
            /* Compare the results */
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i])
                    throw new UnauthorizedAccessException();

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