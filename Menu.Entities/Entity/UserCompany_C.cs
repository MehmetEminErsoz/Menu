using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class UserCompany_C : IEntityWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [ForeignKey("IdCompany")]
        public int? IdCompany { get; set; }
        public Company? Company { get; set; }

        [ForeignKey("IdRole")]
        public string? IdRole { get; set; }
        public Role? Role { get; set; }

        [ForeignKey("IdUser")]
        public int? IdUser { get; set; }
        public User? User { get; set; }

    }
}
