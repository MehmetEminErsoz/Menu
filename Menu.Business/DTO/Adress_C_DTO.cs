using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Adress_C_DTO : IDtoWithId
    {
        [Key]
        public int Id { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int? IdPerson { get; set; }

        public int IdAdress { get; set; }

        public int IdAdressType { get; set; }

        public int? IdCompany { get; set; }

        /*
        public  Adress_DTO Adress { get; set; }

        public  AdressType_DTO AdressType { get; set; }

        public  Company_DTO Company { get; set; }

        public  Person_DTO Person { get; set; }
        */
    }
}
