using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Customer_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdPerson { get; set; }

        [Required]
        [StringLength(15)]
        public string IpAdress { get; set; }

        public bool IsApproved { get; set; }

        //public int Person { get; set; }
    }
}
