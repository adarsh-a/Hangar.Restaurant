﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;

namespace Hangar.Restaurant.DB.Repository
{
    public class SQLRepository<T> : IRepositoryBase<T> where T : class
    {
        internal RestaurantDbContext context;
        internal DbSet<T> DbSet;

        public SQLRepository(RestaurantDbContext dbContext)
        {
            context = dbContext;
            DbSet = context.Set<T>();
        }


        public IQueryable<T> Collection()
        {
            return DbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var entity = Find(Id);
            if(context.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }

            DbSet.Remove(entity);
        }

        public T Find(string Id)
        {
            return DbSet.Find(Id);
        }

        public void Insert(T entity)
        {
            DbSet.Add(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}