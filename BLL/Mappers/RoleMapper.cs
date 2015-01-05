using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Mappers
{
    public class RoleMapper : IMapper<Role, DAL.Role>
    {
        public Role GetBllEntity(DAL.Role dalEntity)
        {
            var role = new Role()
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };
            if (dalEntity.Users == null || dalEntity.Users.Count == 0)
                return role;

            var dalUsers = dalEntity.Users;
            var users = dalUsers.Select(dalUser => new UserMapper().GetBllEntity(dalUser)).ToList();
            role.Users = users;
            return role;
        }

        public DAL.Role GetDalEntity(Role objectEntity)
        {
            var dalRole = new DAL.Role()
            {
                Id = objectEntity.Id,
                Name = objectEntity.Name
            };
            if (objectEntity.Users == null || objectEntity.Users.Count == 0)
                return dalRole;

            var bllUsers = objectEntity.Users;
            var users = bllUsers.Select(bllUser => new UserMapper().GetDalEntity(bllUser)).ToList();
            dalRole.Users = users;
            return dalRole;
        }
    }
}
