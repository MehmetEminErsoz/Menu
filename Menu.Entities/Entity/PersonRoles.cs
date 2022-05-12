
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Entity
{
    
    public class PersonRoles : IdentityUserRole<int> 
    {
      

        public override int UserId { get; set; }
        public Person? Person { get; set; }

        public override int RoleId { get; set; }
        public Role? Role { get; set; }

        
    }
}
