using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Menu : IEntityWithIdName
    {
        public Menu()
        {
            MenuPackageProduct_C = new HashSet<MenuPackageProduct_C>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCompany { get; set; }

        public virtual Company Company { get; set; }

       
        public virtual ICollection<MenuPackageProduct_C> MenuPackageProduct_C { get; set; }
    }
}
