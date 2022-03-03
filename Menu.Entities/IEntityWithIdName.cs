using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Entities
{
    public interface IEntityWithIdName : IEntityWithId
    {
        public string Name { get; set; }
    }
}
