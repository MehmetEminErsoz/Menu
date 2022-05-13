using Menu.DataAccess.Abstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class UserCompany_CRepository : GenericRepository<UserCompany_C>,IUserCompany_CRepository
    {
        public MenuDbContext db;
        public UserCompany_CRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }


        public UserCompany_C SetByEmail(UserCompany_C record)
        {
            return null;
        }

        
    }
}
