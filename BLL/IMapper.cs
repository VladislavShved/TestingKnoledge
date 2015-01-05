using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;
using DAL.Interfaces;

namespace BLL
{
    public interface IMapper<TObject, TDal>
        where TObject : IEntity
        where TDal : IEntity
    {
        TObject GetBllEntity(TDal dalEntity);
        TDal GetDalEntity(TObject objectEntity);
    }
}
