using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace WebApplication2.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public List<int> Roles { get; set; }
        public string Email { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}