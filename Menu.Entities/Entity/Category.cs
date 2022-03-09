using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Category : IEntityWithIdName
    {
        public Category()
        {
            Package = new HashSet<Package>();
            Product = new HashSet<Product>();
            SubCategory = new HashSet<SubCategory>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("IdCompany")]
        public int? IdCompany { get; set; }
        public Company? Company { get; set; }

        public  ICollection<Package> Package { get; set; }
        public  ICollection<Product> Product { get; set; }
        public  ICollection<SubCategory> SubCategory { get; set; }
    }
}
