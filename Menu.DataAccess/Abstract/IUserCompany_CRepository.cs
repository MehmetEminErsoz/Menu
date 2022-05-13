using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Abstract
{
    public interface IUserCompany_CRepository : IGenericRepository<UserCompany_C>
    {
        public UserCompany_C SetByEmail(UserCompany_C record);
    }
}
