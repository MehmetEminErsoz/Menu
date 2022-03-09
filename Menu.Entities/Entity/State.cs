using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class State : IEntityWithIdName
    {
        public State()
        {
            Adress = new HashSet<Adress>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [ForeignKey("IdCity")]
        public int? IdCity { get; set; }
        public City? City { get; set; }

        public ICollection<Adress> Adress { get; set; }
    }
}
