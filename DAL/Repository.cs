using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;

namespace DAL
{
    public class Repository<T> : IRepository<T>
        where T: class, IEntity, new()
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            if (context == null)
            {
                throw new Exception("There is no such context");
            }
            Context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public virtual IEnumerable<T> GetByPredicate(Func<T, bool> predicate)
        {
            return Context.Set<T>().Where(predicate).ToList();
        }

        public virtual void Add(T entity)
        {
            Context.Set<T>().Add(entity);
            Save();
        }

        public void Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            Save();
        }

        public void Save()
        {
            Context.SaveChanges();
        }


        public int GetMaxId()
        {
            return Context.Set<T>().Max(t => t.Id);
        }


        public virtual void Change(int oldId, T newEntity)
        {
            var element = Context.Set<T>().Find(oldId);
            element = newEntity;
            Context.Entry(element).State = EntityState.Modified;
            Save();
        }
    }
}
