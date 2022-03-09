using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class PackageProduct_CRepository : GenericRepository<PackageProduct_C>
    {
        public MenuDbContext db;
        public PackageProduct_CRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
