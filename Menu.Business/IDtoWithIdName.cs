using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business
{
    public interface IDtoWithIdName : IDtoWithId
    {
        public string Name { get; set; }
    }
}
