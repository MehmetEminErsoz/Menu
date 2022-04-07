using Menu.DataAccess.Abstract;
using Menu.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.DataAccess.Concrete
{
    public static class EntityFrameworkQueryableExtensions
    {
        public static IQueryable<TEntity> IncludeAll<TEntity>(this MenuDbContext source) where TEntity : class
        {
            var query = source.Set<TEntity>().AsQueryable();

            foreach (var property in source.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                query = query.Include(property.Name);

            return query;
        }
    }

    public class GenericRepository<Target> : IGenericRepository<Target> where Target : class
    {
        MenuDbContext db;
        DbSet<Target> genericTable;

        public GenericRepository(MenuDbContext _db)
        {
            db = _db;
            genericTable = db.Set<Target>();
        }

        public Target add(Target record)
        {
            
            genericTable.Add(record);
            db.SaveChanges();

            return record;
        }

        public virtual List<Target> getAll(bool load = false)
        {
            if (load)
            {
                var result = db.IncludeAll<Target>().ToList();
                return result;
            }
            return genericTable.ToList();
        }

        public Target getById(int id)
        {
            var result = ((IQueryable<IEntityWithId>)db.IncludeAll<Target>()).FirstOrDefault(s => s.Id == id);

            return (Target)result;
        }

        

        public virtual bool remove(int id)
        {
            var result = getById(id);

            if (result != null)
            {
                genericTable.Remove(result);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool update(Target record)
        {

            try
            {
                db.Entry<Target>(record).State = EntityState.Modified;
                genericTable.Update(record);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
