using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Models
{
    public class AuthenticateResponse
    {

        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public List<int> Roles { get; set; }
        public string Email { get; set; }

        public string Token { get; set; }

        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            Firstname = user.FirstName;
            Lastname = user.LastName;
            Username = user.Username;
            Avatar = user.Avatar;
            Email = user.Email;
            Token = token;
            Roles = user.Roles;
        }
    }
}
