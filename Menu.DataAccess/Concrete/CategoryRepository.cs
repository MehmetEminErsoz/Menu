using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class CategoryRepository : GenericRepository<Category>
    {
        public MenuDbContext db;
        public CategoryRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
