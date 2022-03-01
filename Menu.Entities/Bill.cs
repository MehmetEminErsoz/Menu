using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public class Bill
    {
        public Bill()
        {
            Order = new HashSet<Order>();
        }

        
        public int Id { get; set; }

        public int IdDesk { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalPrice { get; set; }

        public DateTime BillDate { get; set; }

        public double DiscountRate { get; set; }

        public int PaymentMethod { get; set; }

        public int IdUser { get; set; }

        public virtual Desk Desk { get; set; }

        public virtual PaymentMethod PaymentMethod1 { get; set; }

        public virtual User User { get; set; }

        
        public virtual ICollection<Order> Order { get; set; }
    }
}
