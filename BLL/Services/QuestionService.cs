using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interfaces.Objects;
using BLL.Interfaces.Services;
using BLL.Mappers;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class QuestionService : BaseService<Question, DAL.Question, QuestionRepository, QuestionMapper>, IQuestionService
    {
        public QuestionService(QuestionRepository repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
