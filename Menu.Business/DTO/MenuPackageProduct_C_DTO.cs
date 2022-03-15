using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class MenuPackageProduct_C_DTO : IDtoWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        public int IdMenu { get; set; }

        public int? IdPackage { get; set; }

        public int? IdProduct { get; set; }

        public bool Active { get; set; }

        /*public  Menu_DTO Menu { get; set; }

        public  Package_DTO Package { get; set; }

        public  Product_DTO Product { get; set; }

        */
        public int OrderPackageProduct_C { get; set; }
    }
}
