using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Country_DTO : IDtoWithIdName
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public byte CountryNumber { get; set; }


        public int City { get; set; }
    }
}
