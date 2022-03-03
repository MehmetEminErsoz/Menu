using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Company
    {
        public Company()
        {
            Adress_C = new HashSet<Adress_C>();
            Desk = new HashSet<Desk>();
            Menu = new HashSet<Menu>();
            UserCompany_C = new HashSet<UserCompany_C>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Package> Package { get; set; }

        public virtual ICollection<Category> Category { get; set; }

        public virtual ICollection<Product> Product { get; set; }

        public virtual ICollection<Adress_C> Adress_C { get; set; }

        
        public virtual ICollection<Desk> Desk { get; set; }

       
        public virtual ICollection<Menu> Menu { get; set; }

       
        public virtual ICollection<UserCompany_C> UserCompany_C { get; set; }
    }
}
