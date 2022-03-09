using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class CustomerRepository : GenericRepository<Customer>
    {
        public MenuDbContext db;
        public CustomerRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
