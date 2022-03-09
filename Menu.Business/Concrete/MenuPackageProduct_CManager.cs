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
    public class MenuPackageProduct_CManager : GenericManager<MenuPackageProduct_C,MenuPackageProduct_C_DTO>
    {
        IGenericRepository<MenuPackageProduct_C> repository;
        IFunctions functions;
        public MenuPackageProduct_CManager(IGenericRepository<MenuPackageProduct_C> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
