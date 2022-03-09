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
    public class CustomerManager : GenericManager<Customer, Customer_DTO>
    {
        IGenericRepository<Customer> repository;
        IFunctions functions;
        public CustomerManager(IGenericRepository<Customer> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }
    }
}
