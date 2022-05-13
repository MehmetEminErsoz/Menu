using Menu.DataAccess.Abstract;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class UserRepository : GenericRepository<User>,IUserRepository
    {
        public MenuDbContext db;
        public UserRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }


        public User getByEmail(string mail)
        {

            var result = db.User.Where(s => s.Person.Email == mail).FirstOrDefault();
            return result;
        }
    }
}
