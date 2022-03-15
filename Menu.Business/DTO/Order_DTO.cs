using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Order_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public DateTime OrderDate { get; set; }

        [StringLength(50)]
        public string OrderTaker { get; set; }

        public int IdBill { get; set; }

        public string Ps { get; set; }

       // public  Bill_DTO Bill { get; set; }


        public int OrderPackageProduct_C { get; set; }
    }
}
