using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Bill : IEntityWithId
    {
        public Bill()
        {
            Order = new HashSet<Order>();
        }

        
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }


        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public DateTime BillDate { get; set; }

        public double DiscountRate { get; set; }

        [ForeignKey("IdDesk")]
        public int? IdDesk { get; set; }
        public Desk? Desk { get; set; }

        [ForeignKey("IdPaymentMethod")]
        public int? IdPaymentMethod { get; set; }
        public PaymentMethod? PaymentMethod { get; set; }

        [ForeignKey("IdUser")]
        public int? IdUser { get; set; }
        public User? User { get; set; }

        public ICollection<Order> Order { get; set; }
    }
}
