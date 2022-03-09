using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class SubCategory : IEntityWithIdName
    {
        public SubCategory()
        {
            Package = new HashSet<Package>();
            Product = new HashSet<Product>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }


        [ForeignKey("IdCategory")]
        public int? IdCategory { get; set; }
        public Category? Category { get; set; }

        public ICollection<Package>? Package { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}
