//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

using DAL.Interfaces;

namespace DAL
{
    using System;
    using System.Collections.Generic;

    public partial class Test : IEntity
    {
        public Test()
        {
            this.Questions = new HashSet<Question>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Question> Questions { get; set; }
    }
}
