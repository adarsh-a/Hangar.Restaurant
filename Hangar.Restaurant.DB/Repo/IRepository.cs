using Hangar.Restaurant.DB.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Repo
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> Collection();
        void Commit();
        void Delete(string Id);
        T find(string Id);
        void Insert(T t);
        void Update(T t);
    }
}
