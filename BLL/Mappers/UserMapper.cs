using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Mappers
{
    public class UserMapper : IMapper<User, DAL.User>
    {
        public User GetBllEntity(DAL.User dalEntity)
        {
            return new User
            {
                Id = dalEntity.Id,
                Login = dalEntity.Login,
                Name = dalEntity.Name,
                Password = dalEntity.Password,
                Surname = dalEntity.Surname,
                RoleId = dalEntity.RoleId
            };
        }


        public DAL.User GetDalEntity(User objectEntity)
        {
            return new DAL.User
            {
                Id = objectEntity.Id,
                Login = objectEntity.Login,
                Name = objectEntity.Name,
                Password = objectEntity.Password,
                Surname = objectEntity.Surname,
                RoleId = objectEntity.RoleId
            };
        }
    }
}
