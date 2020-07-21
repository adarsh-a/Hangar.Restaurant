using Hangar.Restaurant.Database;
using Hangar.Restaurant.DB.Repo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal RestaurantDbContext DbContext;
        internal DbSet<T> dbSet;

        public Repository(RestaurantDbContext Db)
        {
            DbContext = Db;
            dbSet = Db.Set<T>();
          
        }
    public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public void Delete(string Id)
        {
            var entity = find(Id);
            if(DbContext.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }

        public T find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T entity)
        {
            dbSet.Add(entity);
        }

        public void Update(T entity)
        {
            dbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }
    }
       
    
}
