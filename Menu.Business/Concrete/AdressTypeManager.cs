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
    public class AdressTypeManager : GenericManager<AdressType, AdressType_DTO>
    {
        IGenericRepository<AdressType> repository;
        IFunctions functions;
        public AdressTypeManager(IGenericRepository<AdressType> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
