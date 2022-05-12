using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities.Entity
{
    public class AppUserClaim: IdentityUserClaim<int>
    {
        public virtual Person? AppPerson { get; set; }
    }
}
