using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using NetCoreJwtAuth.Entities;
using NetCoreJwtAuth.Helpers;

namespace NetCoreJwtAuth.Services
{

    public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, FirstName = "Admin", LastName = "User", Username = "admin", System = "A", Role = Role.SystemA },
            new User { Id = 2, FirstName = "Normal", LastName = "User", Username = "user", System = "B", Role = Role.SystemB }
        };

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public User Authenticate(string username, string system)
        {
            var user = _users.SingleOrDefault(x => x.Username == username && x.System == system);

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
                    new Claim(ClaimTypes.Name, user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // remove system before returning
            //user.System = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            // return users without system
            return _users.Select(x =>
            {
                return x;
            });
        }

        public User GetById(int id)
        {
            var user = _users.FirstOrDefault(x => x.Id == id);

            // return user without system
            //if (user != null)
            //    user.System = null;

            return user;
        }

    }
}
