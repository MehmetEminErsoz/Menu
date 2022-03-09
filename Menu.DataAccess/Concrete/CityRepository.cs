using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class CityRepository : GenericRepository<City>
    {
        public MenuDbContext db;
        public CityRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
