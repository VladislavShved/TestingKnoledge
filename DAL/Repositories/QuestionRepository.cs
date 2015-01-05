using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class QuestionRepository : Repository<Question>
    {
        public QuestionRepository(DbContext context) : base(context)
        {
        }

        public override void Change(int oldId, Question newEntity)
        {
            var question = Context.Set<Question>().Find(oldId);
            if (question == null || newEntity == null) return;
            if (question.Id != newEntity.Id)
                question.Id = newEntity.Id;
            if (newEntity.Name != null && question.Name != newEntity.Name)
                question.Name = newEntity.Name;
            if (newEntity.Text != null && question.Text != newEntity.Text)
                question.Text = newEntity.Text;
            Context.Entry(question).State = EntityState.Modified;
            Save();
        }
    }
}
