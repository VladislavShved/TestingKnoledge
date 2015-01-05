using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TestRepository : Repository<Test>
    {
        public TestRepository(DbContext context) : base(context)
        {
        }

        public override void Change(int oldId, Test newEntity)
        {
            var test = Context.Set<Test>().Find(oldId);
            if (test == null || newEntity == null) return;

            if (test.Id != newEntity.Id)
                test.Id = newEntity.Id;
            if (test.Name != null && test.Name != newEntity.Name)
                test.Name = newEntity.Name;


            Context.Entry(test).State = EntityState.Modified;
            Save();
        }
    }
}
