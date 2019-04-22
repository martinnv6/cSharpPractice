using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using NetCoreJwtAuth.Entities;
using NetCoreJwtAuth.Helpers;
using NetCoreJwtAuth.Models;

namespace NetCoreJwtAuth.Services
{

    public interface IUserService
    {
        Users Authenticate(string keyval);
        IEnumerable<Users> GetAll();
        Users GetById(string id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        //private List<User> _users = new List<User>
        //{
        //    new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", System = "A", Role = Role.SystemA },
        //    new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", System = "B", Role = Role.SystemB }
        //};

        private readonly AppSettings _appSettings;
        private readonly IMongoCollection<Users> _users;
        public UserService(IOptions<AppSettings> appSettings, IConfiguration config)
        {
            _appSettings = appSettings.Value;
            var client = new MongoClient(config.GetConnectionString("UserDb"));
            var database = client.GetDatabase("local");
            _users = database.GetCollection<Users>("users");
        }

        public Users Authenticate(string keyval)
        {
            var user = _users.Find<Users>(x => x.Key == keyval).FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.System, user.System.ToString()),
                    new Claim(ClaimTypes.Authentication, user.Key.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Key = keyval;

            // remove system before returning
            //user.System = null;

            return user;
        }

        public IEnumerable<Users> GetAll()
        {
            // return users without system
            return _users.Find<Users>(user => true).ToList();
        }

        public Users GetById(string keyVal)
        {
            var user = _users.Find<Users>(book => book.Key == keyVal).FirstOrDefault();

            // return user without system
            //if (user != null)
            //    user.System = null;

            return user;
        }

    }
}
