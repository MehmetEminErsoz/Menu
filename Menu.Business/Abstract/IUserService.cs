using Menu.Business.DTO;
using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Business.Abstract
{
    public interface IUserService : IGenericService<User_DTO>
    {
        public User getByEmail(string mail);
    }
}
