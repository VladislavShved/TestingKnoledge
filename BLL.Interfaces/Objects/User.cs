using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces.Objects
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Surname { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
