using Menu.Business.DTO;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Abstract
{
    public interface IProductService : IGenericService<Product_DTO>
    {
        public List<Product> getByIdCompany(int idCompany);
    }
}
