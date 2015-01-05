using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class VariantRepository : Repository<Variant>
    {
        public VariantRepository(DbContext context) : base(context)
        {
        }

        public override void Change(int oldId, Variant newEntity)
        {
            var variant = Context.Set<Variant>().Find(oldId);
            if (variant == null || newEntity == null) return;

            if (variant.Id != newEntity.Id)
                variant.Id = newEntity.Id;
            if (variant.Text != null && variant.Text != newEntity.Text)
                variant.Text = newEntity.Text;
            if (variant.IsCorrect != newEntity.IsCorrect)
                variant.IsCorrect = newEntity.IsCorrect;

            Context.Entry(variant).State = EntityState.Modified;
            Save();
        }
    }
}
