using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class OrderPackageProduct_C
    {
        public int Id { get; set; }

        public int  IdOrder { get; set; }

        public int IdMenuPackageProduct_C { get; set; }

        public virtual MenuPackageProduct_C MenuPackageProduct_C { get;set; }

        public virtual Order Order { get; set; }
    }
}
