using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class PackageProduct_C
    {
        public int Id { get; set; }

        public int IdPackage { get; set; }

        public int IdProduct { get; set; }

        public byte Piece { get; set; }

        public virtual Package Package { get; set; }

        public virtual Product Product { get; set; }
    }
}
