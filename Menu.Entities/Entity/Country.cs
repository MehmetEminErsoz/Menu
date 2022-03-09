using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Country : IEntityWithIdName
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte CountryNumber { get; set; }

        public ICollection<City> City { get; set; }
    }
}
