using Menu.Business.DTO;
using Menu.Business.UniversalClassesAbstract;
using Menu.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Concrete
{
    public class MenuManager : GenericManager<Menu.Entities.Menu, Menu_DTO>
    {
        IGenericRepository<Menu.Entities.Menu> repository;
        IFunctions functions;
        public MenuManager(IGenericRepository<Menu.Entities.Menu> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
