
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        private readonly DbContext _context;

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }

    }
}
