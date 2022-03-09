using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public bool Active { get; set; }

        [ForeignKey("IdMenu")]
        public int? IdMenu { get; set; }
        public Menu? Menu { get; set; }

        [ForeignKey("IdPackage")]
        public int? IdPackage { get; set; }
        public Package? Package { get; set; }

        [ForeignKey("IdProduct")]
        public int? IdProduct { get; set; }
        public Product? Product { get; set; }

        public ICollection<OrderPackageProduct_C> OrderPackageProduct_C { get; set; }
    }
}
