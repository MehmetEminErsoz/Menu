using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class User
    {
        public User()
        {
            Bill = new HashSet<Bill>();
            UserCompany_C = new HashSet<UserCompany_C>();
        }

        public int Id { get; set; }

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

       
        public virtual ICollection<Bill> Bill { get; set; }

        public virtual Person Person { get; set; }

        
        public virtual ICollection<UserCompany_C> UserCompany_C { get; set; }
    }
}
