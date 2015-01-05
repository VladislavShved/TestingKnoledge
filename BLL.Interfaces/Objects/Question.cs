using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interfaces;

namespace BLL.Interfaces.Objects
{
    public class Question : IEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int TestId { get; set; }

        public List<bool> SelectedVariant { get; set; }
        public virtual Test Test { get; set; }
        public virtual List<Variant> Variants { get; set; }

        public int NumberAnsers
        {
            get
            {
                if (Variants == null)
                    return 0;
                else
                    return Variants.Count(var => var.IsCorrect); 
            }
        }

        public bool Check(List<Variant> ansers)
        {
            return ansers.Count == Variants.Count && ansers.All(variant => variant.IsCorrect);
        }
    }
}
