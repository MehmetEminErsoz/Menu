using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public interface IEntityWithId
    {
        [Key]
        public int Id { get; set; }
    }
}
