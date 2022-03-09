using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class CompanyRepository : GenericRepository<Company>
    {
        public MenuDbContext db;
        public CompanyRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
