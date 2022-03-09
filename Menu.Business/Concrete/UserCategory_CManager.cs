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
    public class UserCompany_CManager : GenericManager<UserCompany_C,UserCompany_C_DTO>
    {
        IGenericRepository<UserCompany_C> repository;
        IFunctions functions;
        public UserCompany_CManager(IGenericRepository<UserCompany_C> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
