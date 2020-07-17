using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.Contracts
{
    public interface IRepositoryBase<T> where T:class
    {
        IQueryable<T> Collection();
        T Find(string id);
        void Insert(T entity);
        void Delete(string id); // find id to delete object
        void Update(T entity);
        void Commit();
    }
}
