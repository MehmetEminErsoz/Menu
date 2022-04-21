using Menu.Entities.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Person : IdentityUser
    {
        
        public Person()
        {
            Adress_C = new HashSet<Adress_C>();
            Customer = new HashSet<Customer>();
            User = new HashSet<User>();
        }
        public override string Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }
        
        public ICollection<IdentityUser> Users { get; set; }
        public ICollection<Adress_C> Adress_C { get; set; }
        public ICollection<Customer> Customer { get; set; }
        public ICollection<User> User { get; set; }




        public ICollection<PersonRoles> PersonRoles { get; set; }
    }
}
