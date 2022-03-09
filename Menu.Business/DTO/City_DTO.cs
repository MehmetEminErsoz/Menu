using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class City_DTO :  IDtoWithIdName
    {
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

        public int IdCountry { get; set; }

        public  Country_DTO Country { get; set; }

        //Diğer tablo referanslarını int olarak tanımladım.
        public int State { get; set; }

    }
}
