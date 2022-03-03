using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Bill_DTO :IDtoWithId
    {
        public int Id { get; set; }

        public int IdDesk { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public DateTime BillDate { get; set; }

        public double DiscountRate { get; set; }

        public int PaymentMethod { get; set; }

        public int IdUser { get; set; }

        public  Desk_DTO Desk { get; set; }

        public  PaymentMethod_DTO PaymentMethod1 { get; set; }

        public  User_DTO User { get; set; }




        //Diğer tablo referanslarını int olarak tanımladım.
        public  int Order { get; set; }
    }
}
