using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Company : IEntityWithIdName
    {
        public Company()
        {
            Adress_C = new HashSet<Adress_C>();
            Desk = new HashSet<Desk>();
            Menu = new HashSet<Menu>();
            UserCompany_C = new HashSet<UserCompany_C>();
        }
        [Required]
        [Key]
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int? DeskCount { get; set; }
        public  ICollection<Package> Package { get; set; }
        public  ICollection<Category> Category { get; set; }
        public  ICollection<Product> Product { get; set; }
        public  ICollection<Adress_C> Adress_C { get; set; }
        public  ICollection<Desk> Desk { get; set; }
        public  ICollection<Menu> Menu { get; set; }
        public  ICollection<UserCompany_C> UserCompany_C { get; set; }
    }
}
