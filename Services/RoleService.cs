using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication2.Entities;

namespace WebApplication2.Services
{
    public interface IRoleService
    {
        IEnumerable<Role> GetAll();
        IEnumerable<Role> GetByIds(List<int> ids);
        Role GetById(int id);
    }

    public class RoleService : IRoleService
    {
        private List<Role> _roles = new List<Role>
        {
            new Role { Id = 1, Name = "Admin" },
            new Role { Id = 2, Name = "Manager" },
            new Role { Id = 3, Name = "Operator" },
            new Role { Id = 4, Name = "Employee" }
        };
        public IEnumerable<Role> GetAll()
        {
            return _roles;
        }

        public Role GetById(int id)
        {
            return _roles.SingleOrDefault(q => q.Id == id);
        }

        public IEnumerable<Role> GetByIds(List<int> ids)
        {
            return _roles.Where(q => ids.Contains(q.Id));
        }
    }
}
