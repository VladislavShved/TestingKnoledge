using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;

namespace BLL
{
    public abstract class BaseService<TObject, TDal, TRepository, TEntityMapper> : IService<TObject>
        where TObject: class, IEntity
        where TDal: class, IEntity
        where TRepository: IRepository<TDal>
        where TEntityMapper : IMapper<TObject, TDal>, new()
    {

        protected readonly IUnitOfWork UnitOfWork;
        protected readonly TRepository Repository;
        protected readonly IMapper<TObject, TDal> Mapper = new TEntityMapper();

        protected BaseService(TRepository repository, IUnitOfWork unitOfWork)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;
        }

        public IEnumerable<TObject> GetAll()
        {
            var dalEntities = Repository.GetAll().ToList();
            var bllEntities = new List<TObject>();
            foreach (var dalEntity in dalEntities)
            {
                bllEntities.Add(Mapper.GetBllEntity(dalEntity));
            }
            return bllEntities;
        }

        public TObject GetById(int id)
        {
            var dalEntity = Repository.GetById(id);
            return Mapper.GetBllEntity(dalEntity);
        }

        public IEnumerable<TObject> GetByPredicate(Func<TObject, bool> predicate)
        {
            var objects = GetAll().Where(predicate);
            return objects.ToList();
        }

        public void Add(TObject entity)
        {
            Repository.Add(Mapper.GetDalEntity(entity));
            UnitOfWork.Commit();
        }

        public void Delete(TObject entity)
        {
            Repository.Delete(Repository.GetById(entity.Id));
            UnitOfWork.Commit();
        }

        public void Save()
        {
            Repository.Save();
        }


        public int GetMaxId()
        {
            return Repository.GetMaxId();
        }


        public void Change(int id, TObject entity)
        {
            Repository.Change(id, Mapper.GetDalEntity(entity));
        }
    }
}
