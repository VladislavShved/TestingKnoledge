using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;

namespace BLL.Mappers
{
    public class TestMapper : IMapper<Test, DAL.Test>
    {
        public Test GetBllEntity(DAL.Test dalEntity)
        {
            var test = new Test
            {
                Id = dalEntity.Id,
                Name = dalEntity.Name
            };

            if (dalEntity.Questions == null || dalEntity.Questions.Count == 0)
                return test;

            var dalQuestions = dalEntity.Questions;
            var questions = dalQuestions.Select(dalQuestion => new QuestionMapper().GetBllEntity(dalQuestion)).ToList();
            test.Questions = questions;
            return test;
        }



        public DAL.Test GetDalEntity(Test objectEntity)
        {
            var test = new DAL.Test
            {
                Id = objectEntity.Id,
                Name = objectEntity.Name
            };

            if (objectEntity.Questions == null)
                return test;

            var objQuestions = objectEntity.Questions;
            var questions = objQuestions.Select(objQuestion => new QuestionMapper().GetDalEntity(objQuestion)).ToList();
            test.Questions = questions;
            return test;
        }
    }
}
