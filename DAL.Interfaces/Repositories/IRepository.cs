using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces.Repositories
{
    public interface IRepository<T> where T: class, IEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        IEnumerable<T> GetByPredicate(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        int GetMaxId();
        void Change(int oldId, T newEntity);
        void Save();
    }
}
