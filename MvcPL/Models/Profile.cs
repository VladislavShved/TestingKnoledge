using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.Interfaces.Objects;

namespace MvcPL.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}