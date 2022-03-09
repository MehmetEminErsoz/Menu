using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class PackageProduct_C : IEntityWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }
        public byte Piece { get; set; }


        [ForeignKey("IdPackage")]
        public int? IdPackage { get; set; }
        public Package? Package { get; set; }

        [ForeignKey("IdProduct")]
        public int? IdProduct { get; set; }
        public Product? Product { get; set; }
    }
}
