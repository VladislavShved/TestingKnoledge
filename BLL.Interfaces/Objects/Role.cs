using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces.Objects
{
    public class Role : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; } 
    }
}
