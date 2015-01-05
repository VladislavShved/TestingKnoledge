using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;
using BLL.Services;
using DAL;
using DAL.Repositories;

namespace ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new TestingDbEntities();
            var repository = new RoleRepository(context);
            var service = new RoleService(repository, new UnitOfWork(context));

            var roles = service.GetAll();

            

        }
    }
}
