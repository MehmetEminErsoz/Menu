using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Product : IEntityWithIdName
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

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [ForeignKey("IdCompany")]
        public int? IdCompany { get; set; }
        public Company? Company { get; set; }

        [ForeignKey("IdCategory")]
        public int? IdCategory { get; set; }
        public Category? Category { get; set; }

        [ForeignKey("IdSubCategory")]
        public int? IdSubCategory { get; set; }
        public SubCategory? SubCategory { get; set; }


        public ICollection<MenuPackageProduct_C> MenuPackageProduct_C { get; set; }
        
        public ICollection<PackageProduct_C> PackageProduct_C { get; set; }

        
    }
}
