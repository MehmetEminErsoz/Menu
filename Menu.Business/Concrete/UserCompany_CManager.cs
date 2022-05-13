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
    public class UserCompany_CManager : GenericManager<UserCompany_C,UserCompany_C_DTO>,IUserCompany_CService
    {
        IGenericRepository<UserCompany_C> repository;
        IUserRepository userRepository;
        IFunctions functions;
        public UserCompany_CManager(IGenericRepository<UserCompany_C> _repository, IFunctions _functions,IUserRepository _userRepository) : base(_repository, _functions)
        {
            repository = _repository;
            functions = _functions;
            userRepository = _userRepository;
        }

        public UserCompany_C SetRoleByEmail(string mail,int idCompany,int idRole)
        {
            var user = userRepository.getByEmail(mail);

            UserCompany_C userCompany = new() {
            IdCompany = idCompany,
            IdUser=user.Id,
            IsActive=true,
            IsDeleted=false,
            CreateTime=DateTime.Now,
            IdRole=idRole
            };

            var result = repository.add(userCompany);
            return result;
        }
    }
}
