using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class MenuRepository : GenericRepository<Menu.Entities.Menu>
    {
        public MenuDbContext db;
        public MenuRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
