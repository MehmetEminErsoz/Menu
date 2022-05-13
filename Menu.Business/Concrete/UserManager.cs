using Menu.Business.Abstract;
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
    public class UserManager : GenericManager<User,User_DTO>,IUserService
    {
        IGenericRepository<User> repository;
        IFunctions functions;
        public UserManager(IGenericRepository<User> _repository, IFunctions _functions) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
        }

        public User getByEmail(string mail)
        {

            var x = repository.getAll();

            var z = x.Where(s => s.Person.Email == mail).FirstOrDefault();
            return z;
        }
    }
}
