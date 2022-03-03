using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public int IdCity { get; set; }

        
        public virtual ICollection<Adress> Adress { get; set; }

        public virtual City City { get; set; }
    }
}
