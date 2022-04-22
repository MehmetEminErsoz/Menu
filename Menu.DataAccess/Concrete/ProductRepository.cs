using Menu.DataAccess.Abstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class ProductRepository : GenericRepository<Product>,IProductRepository
    {
        public MenuDbContext db;
        public ProductRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }

        public List< Product> getByIdCompany(int idCompany)
        {
            var result = db.IncludeAll<Product>().ToList();
            result.Where(s=>s.IdCompany == idCompany).ToList();
            return result;
        }


    }
}
