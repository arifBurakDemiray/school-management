using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using SchoolManagement.API.Models;
using SchoolManagement.API.Security;
using SchoolManagement.API.Data;

namespace SchoolManagament.API.Security
{
    public interface IUserService
    {
        AuthenticationResponse Authenticate(AuthenticationRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private readonly IRepo<User> _users;

        private readonly AppSettings _appSettings;

        public UserService(IOptions<AppSettings> appSettings,IRepo<User> users)
        {
            _appSettings = appSettings.Value;
            _users = users;
        }

        public AuthenticationResponse Authenticate(AuthenticationRequest model)
        {
            var users = _users.GetByPredicate(x => x.Username == model.Username && x.Password == model.Password);

            //var user = users[0];
            // return null if user not found
            if (users.Count < 1) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(users[0]);

            return new AuthenticationResponse(users[0], token);
        }

        public IEnumerable<User> GetAll()
        {
            List<User> users =  _users.GetAll().Result;
            return users;
        }

        public User GetById(int id)
        {
            return _users.GetById(id).Result;
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim(ClaimTypes.Role, "ADMIN") }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}