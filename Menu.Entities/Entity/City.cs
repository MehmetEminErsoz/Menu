using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class City: IEntityWithIdName
    {
        public City()
        {
            State = new HashSet<State>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string CityNumber { get; set; }

        [ForeignKey("IdCountry")]
        public int? IdCountry { get; set; }
        public Country? Country { get; set; }

        public ICollection<State> State { get; set; }
    }
}
