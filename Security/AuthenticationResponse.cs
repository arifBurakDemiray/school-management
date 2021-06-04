using SchoolManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.API.Security
{
    public class AuthenticationResponse
    {
        public int RoleId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }


        public AuthenticationResponse(User user, string token)
        {
            RoleId = user.RoleId;
            FirstName = user.Name;
            LastName = user.Surname;
            Username = user.Username;
            Token = token;
        }
    }
}
