using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces.Repositories;

namespace DAL.Repositories
{
    public class RoleRepository : Repository<Role>
    {
        public RoleRepository(DbContext context) : base(context)
        {
        }

        public override void Change(int oldId, Role newEntity)
        {
            var role = Context.Set<Role>().Find(oldId);
            if (role == null || newEntity == null) return;

            if (role.Id != newEntity.Id)
                role.Id = newEntity.Id;
            if (role.Name != null && role.Name != newEntity.Name)
                role.Name = newEntity.Name;

            
            Context.Entry(role).State = EntityState.Modified;
            Save();
        }
    }
}
