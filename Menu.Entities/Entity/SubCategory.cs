using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCategory { get; set; }

        public virtual Category Category { get; set; }

        
        public virtual ICollection<Package> Package { get; set; }

        
        public virtual ICollection<Product> Product { get; set; }
    }
}
