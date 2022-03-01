using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class AdressType
    {
        public AdressType()
        {
            Adress_C = new HashSet<Adress_C>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        
        public virtual ICollection<Adress_C> Adress_C { get; set; }
    }
}
