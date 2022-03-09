using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class OrderPackageProduct_C : IEntityWithId
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [ForeignKey("IdOrder")]
        public int? IdOrder { get; set; }
        public Order? Order { get; set; }

        [ForeignKey("IdMenuPackageProduct_C")]
        public int? IdMenuPackageProduct_C { get; set; }
        public MenuPackageProduct_C? MenuPackageProduct_C { get; set; }
    }
}
