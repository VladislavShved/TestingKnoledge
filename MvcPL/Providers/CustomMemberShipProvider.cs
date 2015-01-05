using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Security;
using BLL.Interfaces.Services;
using BLL.Services;
using DAL;
using DAL.Repositories;
using User = BLL.Interfaces.Objects.User;

namespace MvcPL.Providers
{
    public class CustomMemberShipProvider : MembershipProvider
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public CustomMemberShipProvider()
        {
            var context = new TestingDbEntities();
            _userService = new UserService(new UserRepository(context), new UnitOfWork(context));
            _roleService = new RoleService(new RoleRepository(context), new UnitOfWork(context));
        }

        public CustomMemberShipProvider(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }


        public override bool ValidateUser(string username, string password)
        {
            var user = _userService.GetByPredicate(us => us.Login == username).FirstOrDefault();

            if (user != null && Crypto.VerifyHashedPassword(user.Password, password))
                return true;
            return false;
        }

        public MembershipUser CreateUser(string login, string name, string surname, string password)
        {
            MembershipUser membershipUser = GetUser(login, false);

            if (membershipUser == null)
            {
                var hashPassword = Crypto.HashPassword(password);
                var user = new User
                {
                    Id = _userService.GetMaxId() + 1,
                    Name = name,
                    Surname = surname,
                    Login = login,
                    Password = hashPassword,
                    RoleId = 1,
                    Role = _roleService.GetById(1)
                };

                _userService.Add(user);
                _userService.Save();
                membershipUser = GetUser(login, false);
                return membershipUser;
            }
            return null;
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            var user = _userService.GetByPredicate(us => us.Login == username).FirstOrDefault();
            
            if (user != null)
            {
                var membershipUser = new MembershipUser("MyMembershipProvider", user.Login, null, null, null, null, false, false, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
                return membershipUser;
            }
            return null;
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
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

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        
    }
}