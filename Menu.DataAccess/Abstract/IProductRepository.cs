using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Abstract
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        public List< Product> getByIdCompany(int idCompany);
    }
}
