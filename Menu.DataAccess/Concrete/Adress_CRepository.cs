using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class Adress_CRepository : GenericRepository<Adress_C>
    {
        public MenuDbContext db;
        public Adress_CRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
