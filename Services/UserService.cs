using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using WebApplication2.Entities;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Avatar = "https://png.pngtree.com/png-clipart/20190516/original/pngtree-users-vector-icon-png-image_3725294.jpg", Email = "abc@gdf.com", FirstName = "Admin", LastName = "User", Username = "admin", Password = "admin123", Roles = new List<int> { 1 } },
            new User { Id = 2, Avatar = "https://png.pngtree.com/png-clipart/20190516/original/pngtree-users-vector-icon-png-image_3725294.jpg", Email = "abc@gdf.com", FirstName = "Manager", LastName = "User", Username = "manager", Password = "manager123", Roles = new List<int> { 2 } } ,
            new User { Id = 3, Avatar = "https://png.pngtree.com/png-clipart/20190516/original/pngtree-users-vector-icon-png-image_3725294.jpg", Email = "abc@gdf.com", FirstName = "Operator", LastName = "User", Username = "operator", Password = "operator123", Roles = new List<int> { 3 } },
            new User { Id = 1, Avatar = "https://png.pngtree.com/png-clipart/20190516/original/pngtree-users-vector-icon-png-image_3725294.jpg", Email = "abc@gdf.com", FirstName = "Employee", LastName = "User", Username = "employee", Password = "employee123", Roles = new List<int> { 4 } }
        };


        public UserService()
        {
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            return "";
        }
    }
}