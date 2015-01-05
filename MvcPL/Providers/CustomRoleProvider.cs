using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL;
using DAL.Repositories;
using Role = BLL.Interfaces.Objects.Role;

namespace MvcPL.Providers
{
    public class CustomRoleProvider : RoleProvider
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CustomRoleProvider()
        {
            var context = new TestingDbEntities();
            _userService = new UserService(new UserRepository(context), new UnitOfWork(context));
            _roleService = new RoleService(new RoleRepository(context), new UnitOfWork(context));
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = {};
            var user = _userService.GetByPredicate(us => us.Login == username).FirstOrDefault();
            if (user != null)
            {
                var role = _roleService.GetById(user.RoleId);
                if (role != null)
                    roles = new[] {role.Name};
            }
            return roles;
        }

        public override void CreateRole(string roleName)
        {
            var role = new Role
            {
                Id = _roleService.GetMaxId() + 1,
                Name = roleName
            };
            _roleService.Add(role);
            _roleService.Save();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            var user = _userService.GetByPredicate(us => us.Login == username).FirstOrDefault();
            var role = _roleService.GetByPredicate(rl => rl.Name == roleName).FirstOrDefault();
            return user != null && role != null && role.Id == user.RoleId;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}