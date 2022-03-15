using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class OrderPackageProduct_C_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdOrder { get; set; }

        public int IdMenuPackageProduct_C { get; set; }

       // public  MenuPackageProduct_C_DTO MenuPackageProduct_C { get; set; }

       // public Order_DTO Order { get; set; }
    }
}
