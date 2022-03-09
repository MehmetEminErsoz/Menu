using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Customer : IEntityWithId
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string IpAdress { get; set; }

        public bool IsApproved { get; set; }

        [ForeignKey("IdPerson")]
        public int? IdPerson { get; set; }
        public Person? Person { get; set; }
    }
}
