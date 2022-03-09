using Menu.Business.DTO;
using Menu.Business.UniversalClassesAbstract;
using Menu.DataAccess.Abstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Concrete
{
    public class OrderPackageProduct_CManager : GenericManager<OrderPackageProduct_C,OrderPackageProduct_C_DTO>
    {
        IGenericRepository<OrderPackageProduct_C> repository;
        IFunctions functions;
        public OrderPackageProduct_CManager(IGenericRepository<OrderPackageProduct_C> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
