﻿using Menu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public class PackageRepository : GenericRepository<Package>
    {
        public MenuDbContext db;
        public PackageRepository(MenuDbContext _db) : base(_db)
        {
            db = _db;
        }
    }
}
