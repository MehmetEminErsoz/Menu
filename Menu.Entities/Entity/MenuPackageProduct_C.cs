using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class MenuPackageProduct_C : IEntityWithId
    {
        public MenuPackageProduct_C()
        {
            OrderPackageProduct_C = new HashSet<OrderPackageProduct_C>();
        }

        public int Id { get; set; }

        public int IdMenu { get; set; }

        public int? IdPackage { get; set; }

        public int? IdProduct { get; set; }

        public bool Active { get; set; }

        public virtual Menu Menu { get; set; }

        public virtual Package Package { get; set; }

        public virtual Product Product { get; set; }

        
        public virtual ICollection<OrderPackageProduct_C> OrderPackageProduct_C { get; set; }
    }
}
