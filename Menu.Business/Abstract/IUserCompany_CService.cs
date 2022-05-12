using Menu.Business.DTO;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Abstract
{
    public interface IUserCompany_CService : IGenericService<UserCompany_C_DTO>
    {
        public UserCompany_C SetByEmail(string mail,int idCompany,int idRole);
    }
}
