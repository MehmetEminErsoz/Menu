using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class User_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdPerson { get; set; }

        [Required]
        [StringLength(50)]
        public string SecondMail { get; set; }

        [Required]
        [StringLength(14)]
        public string Phone { get; set; }

        [Required]
        [StringLength(50)]
        public string PasswordQuestion { get; set; }

        [Required]
        [StringLength(50)]
        public string PasswordAnswer { get; set; }


        public int Bill { get; set; }

        //public Person_DTO Person { get; set; }


        public int UserCompany_C { get; set; }
    }
}
