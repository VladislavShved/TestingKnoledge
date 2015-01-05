using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class UserService : BaseService<User, DAL.User, UserRepository, UserMapper>, IUserService
    {
        public UserService(UserRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
