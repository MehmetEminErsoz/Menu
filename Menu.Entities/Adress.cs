using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Adress
    {
        public Adress()
        {
            Adress_C = new HashSet<Adress_C>();
        }

        public int Id { get; set; }

        public int IdState { get; set; }

        [Required]
      
        public string Adressline1 { get; set; }

       

        
        public virtual ICollection<Adress_C> Adress_C { get; set; }

        public virtual State State { get; set; }
    }
}
