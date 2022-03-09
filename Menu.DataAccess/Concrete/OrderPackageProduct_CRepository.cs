using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class OrderPackageProduct_CRepository : GenericRepository<OrderPackageProduct_C>
    {
        public MenuDbContext db;
        public OrderPackageProduct_CRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
