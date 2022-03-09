using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Order :IEntityWithId
    {
        public Order()
        {
            OrderPackageProduct_C = new HashSet<OrderPackageProduct_C>();
        }

        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }


        public DateTime OrderDate { get; set; }

        [StringLength(50)]
        public string OrderTaker { get; set; }

        public string Ps { get; set; }

        [ForeignKey("IdBill")]
        public int? IdBill { get; set; }
        public Bill? Bill { get; set; }

        public  ICollection<OrderPackageProduct_C> OrderPackageProduct_C { get; set; }
    }
}
