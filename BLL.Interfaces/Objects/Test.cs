using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces.Objects
{
    public sealed class Test : IEntity
    {
        public Test()
        {
            Questions = new List<Question>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Question> Questions { get; set; }
    }
}
