using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class AdressRepository : GenericRepository<Adress>
    {
        public MenuDbContext db;
        public AdressRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    
    }
}
