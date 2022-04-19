using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class UserCompany_C_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdCompany { get; set; }

        public string IdUser { get; set; }

        public int IdRole { get; set; }

        /*public  Company_DTO Company { get; set; }

        public  Role_DTO Role { get; set; }

        public  User_DTO User { get; set; }*/
    }
}
