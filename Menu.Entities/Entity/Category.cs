using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCompany { get; set; }

        public virtual Company Company { get; set; }


        public virtual ICollection<Package> Package { get; set; }

        
        public virtual ICollection<Product> Product { get; set; }

       
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
