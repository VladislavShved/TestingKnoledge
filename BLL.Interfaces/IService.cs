using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces
{
    public interface IService<TEntity> where TEntity : class, IEntity
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);
        void Add(TEntity entity);
        void Delete(TEntity entity);
        void Change(int id, TEntity entity);
        int GetMaxId();
        void Save();
    }
}
