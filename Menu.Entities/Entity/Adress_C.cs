using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Adress_C : IEntityWithId
    {
        
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [ForeignKey("IdPerson")]
        public string? IdPerson { get; set; }
        public Person? Person { get; set; }

        [ForeignKey("IdAdress")]
        public int? IdAdress { get; set; }
        public Adress? Adress { get; set; }

        [ForeignKey("IdAdressType")]
        public int? IdAdressType { get; set; }
        public AdressType? AdressType { get; set; }

        [ForeignKey("IdCompany")]
        public int? IdCompany { get; set; }
        public Company? Company { get; set; }        
    }
}
