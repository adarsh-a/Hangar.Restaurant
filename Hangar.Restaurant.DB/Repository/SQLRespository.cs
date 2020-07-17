using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB
{
    public class SQLRespository<T> : IRepositoryBase<T> where T : class
    {
        internal RestaurantDbContext context; // database
        internal DbSet<T> dbset; //table
        
        public SQLRespository(RestaurantDbContext dbContext)
        {
            context = dbContext;
            dbset = context.Set<T>();

        }
        public IQueryable<T> Collection()
        {
            return dbset;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = dbset.Find(id);
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbset.Attach(entity);
                dbset.Remove(entity);
            }
        }

        public T Find(string id)
        {
            return dbset.Find(id);
        }

        public void Insert(T entity)
        {
            dbset.Add(entity); //record
        }

        public void Update(T entity)
        {
            dbset.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}
