using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Desk
    {
        public Desk()
        {
            Bill = new HashSet<Bill>();
        }

        public int Id { get; set; }

        public int IdCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string DeskCode { get; set; }

        [Required]
        [StringLength(50)]
        public string QrCode { get; set; }

       
        public virtual ICollection<Bill> Bill { get; set; }

        public virtual Company Company { get; set; }
    }
}
