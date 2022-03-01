using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class City
    {
        public City()
        {
            State = new HashSet<State>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string CityNumber { get; set; }

        public int IdCountry { get; set; }

        public virtual Country Country { get; set; }

        
        public virtual ICollection<State> State { get; set; }
    }
}
