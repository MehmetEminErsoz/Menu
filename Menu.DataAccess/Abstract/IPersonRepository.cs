using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Abstract
{
    public interface IPersonRepository : IGenericRepository<Person>
    {
        public Person getByEmail(string mail);

    }
}
