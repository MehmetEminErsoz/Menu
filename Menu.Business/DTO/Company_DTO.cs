using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Company_DTO : IDtoWithIdName
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public int DeskCount { get; set; }

        //public  int Package { get; set; }

        //public int Category { get; set; }

        //public int Product { get; set; }

        //public int Adress_C { get; set; }


        //public int Desk { get; set; }


        //public int Menu { get; set; }


        //public int UserCompany_C { get; set; }
    }
}
