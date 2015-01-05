using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Mappers
{
    public class QuestionMapper : IMapper<Question, DAL.Question>
    {
        public Question GetBllEntity(DAL.Question dalEntity)
        {
            var question = new Question
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name,
                TestId = dalEntity.TestId,
                Text = dalEntity.Text
            };
            if (dalEntity.Variants == null)
                return question;

            var dalVariants = dalEntity.Variants;

            var variants = dalVariants.Select(dalVariant => new VariantMapper().GetBllEntity(dalVariant)).ToList();

            question.Variants = variants;
            return question;
        }


        public DAL.Question GetDalEntity(Question objectEntity)
        {
            var question = new DAL.Question
            {
                Id = objectEntity.Id,
                Name = objectEntity.Name,
                TestId = objectEntity.TestId,
                Text = objectEntity.Text
            };
            if (objectEntity.Variants == null)
                return question;

            var objVariants = objectEntity.Variants;

            var variants = objVariants.Select(obj => new VariantMapper().GetDalEntity(obj)).ToList();

            question.Variants = variants;
            return question;
        }
    }
}
