using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class AdressType_DTO : IDtoWithIdName 
    {
        public int Id { get; set; }
        public string Name { get; set; }



        public  int Adress_C { get; set; }
    }
}
