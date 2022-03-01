using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class UserCompany_C
    {
        public int Id { get; set; }

        public int IdCompany { get; set; }

        public int IdUser { get; set; }

        public int IdRole { get; set; }

        public virtual Company Company { get; set; }

        public virtual Role Role { get; set; }

        public virtual User User { get; set; }

    }
}
