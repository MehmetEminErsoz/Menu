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
    public class Role :IdentityRole
    {
        public Role()
        {
            UserCompany_C = new HashSet<UserCompany_C>();
        }

        public override string Id { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public override string Name { get; set; }

        public ICollection<UserCompany_C> UserCompany_C { get; set; }


        public ICollection<PersonRoles> PersonRoles { get; set; }

    }
}
