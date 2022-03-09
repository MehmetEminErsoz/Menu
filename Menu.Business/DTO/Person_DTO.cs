using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Person_DTO :IDtoWithIdName
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
        public string Surname { get; set; }

        public DateTime RegisterDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime Birthday { get; set; }

        public bool Active { get; set; }

        [Required]
        [StringLength(50)]
        public string Mail { get; set; }

        public byte AccessFailedCount { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }


        public int Adress_C { get; set; }


        public int Customer { get; set; }


        public int User { get; set; }
    }
}
