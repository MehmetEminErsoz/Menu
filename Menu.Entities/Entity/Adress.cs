using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Adress : IEntityWithId
    {
        public Adress()
        {
            Adress_C = new HashSet<Adress_C>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }


        [Required]     
        public string Adressline { get; set; }

        [ForeignKey("IdState")]
        public int? IdState { get; set; }
        public State? State { get; set; }

        public virtual ICollection<Adress_C> Adress_C { get; set; }

    }
}
