using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Category_DTO : IDtoWithIdName
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateTime { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCompany { get; set; }
        
        //public Company_DTO Company { get; set; }

        

        //Diğer tablo referanslarını int olarak tanımladım.
        //public int Package { get; set; }

        //public int Product { get; set; }

        //public int SubCategory { get; set; }
    }
}
