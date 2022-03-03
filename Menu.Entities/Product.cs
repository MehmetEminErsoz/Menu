using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Product
    {
        public Product()
        {
            MenuPackageProduct_C = new HashSet<MenuPackageProduct_C>();
            PackageProduct_C = new HashSet<PackageProduct_C>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? IdSubCategory { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int IdCategory { get; set; }

        public int IdCompany { get; set; }

        public virtual Company Company { get; set; }

        public virtual Category Category { get; set; }

       
        public virtual ICollection<MenuPackageProduct_C> MenuPackageProduct_C { get; set; }

        
        public virtual ICollection<PackageProduct_C> PackageProduct_C { get; set; }

        public virtual SubCategory SubCategory { get; set; }
    }
}
