using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Desk : IEntityWithIdName
    {
        public Desk()
        {
            Bill = new HashSet<Bill>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string DeskCode { get; set; }

        [Required]
        public string QrCode { get; set; }

        [ForeignKey("IdCompany")]
        public int? IdCompany { get; set; }
        public Company? Company { get; set; }

        public ICollection<Bill> Bill { get; set; }

        
    }
}
