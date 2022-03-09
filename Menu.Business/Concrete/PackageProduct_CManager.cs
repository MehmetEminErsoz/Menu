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
    public class PackageProduct_CManager : GenericManager<PackageProduct_C,PackageProduct_C_DTO>
    {
        IGenericRepository<PackageProduct_C> repository;
        IFunctions functions;
        public PackageProduct_CManager(IGenericRepository<PackageProduct_C> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
