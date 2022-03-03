using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class Product_DTO : IDtoWithIdName
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int? IdSubCategory { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        public int IdCategory { get; set; }

        public int IdCompany { get; set; }

        public  Company_DTO Company { get; set; }

        public  Category_DTO Category { get; set; }


        public int MenuPackageProduct_C { get; set; }


        public int PackageProduct_C { get; set; }

        public  SubCategory_DTO SubCategory { get; set; }
    }
}
