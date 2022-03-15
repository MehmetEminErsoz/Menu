using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Adress_DTO  : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdState { get; set; }

        [Required]
        public string Adressline { get; set; }

        public int Adress_C { get; set; }

        //public  State_DTO State { get; set; }
    }
}
