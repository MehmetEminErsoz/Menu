using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Role :IEntityWithIdName
    {
        public Role()
        {
            UserCompany_C = new HashSet<UserCompany_C>();
        }

       
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        public virtual ICollection<UserCompany_C> UserCompany_C { get; set; }
    }
}
