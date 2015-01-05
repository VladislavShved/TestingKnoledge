using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Mappers
{
    public class VariantMapper : IMapper<Variant, DAL.Variant>
    {
        public Variant GetBllEntity(DAL.Variant dalEntity)
        {
            return new Variant
            {
                Id = dalEntity.Id,
                QuestionId = dalEntity.QuestionId,
                Text = dalEntity.Text,
                IsCorrect = dalEntity.IsCorrect
            };
        }



        public DAL.Variant GetDalEntity(Variant objectEntity)
        {
            return new DAL.Variant
            {
                Id = (int)objectEntity.Id,
                QuestionId = objectEntity.QuestionId,
                Text = objectEntity.Text,
                IsCorrect = objectEntity.IsCorrect
            };
        }
    }
}
