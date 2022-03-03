using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.DTO
{
    public class SubCategory_DTO : IDtoWithIdName
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int IdCategory { get; set; }

        public virtual Category_DTO Category { get; set; }


        public int Package { get; set; }


        public int Product { get; set; }
    }
}
