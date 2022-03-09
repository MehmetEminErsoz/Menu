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
    public class SubCategoryManager : GenericManager<SubCategory,SubCategory_DTO>
    {
        IGenericRepository<SubCategory> repository;
        IFunctions functions;
        public SubCategoryManager(IGenericRepository<SubCategory> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
