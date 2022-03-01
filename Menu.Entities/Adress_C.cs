using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Adress_C
    {
        public int Id { get; set; }

        public int? IdPerson { get; set; }

        public int IdAdress { get; set; }

        public int IdAdressType { get; set; }

        public int? IdCompany { get; set; }

        public virtual Adress Adress { get; set; }

        public virtual AdressType AdressType { get; set; }

        public virtual Company Company { get; set; }

        public virtual Person Person { get; set; }
    }
}
