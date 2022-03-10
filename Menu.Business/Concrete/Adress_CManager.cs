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
    public class Adress_CManager : GenericManager<Adress_C, Adress_C_DTO>
    {
        IGenericRepository<Adress_C> repository;
        IFunctions functions;

        public Adress_CManager(IGenericRepository<Adress_C> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
