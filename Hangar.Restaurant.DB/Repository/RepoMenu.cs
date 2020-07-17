using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Contracts
{
    class RepoMenu : IRepositoryBase<MenuEntity>
    {
        public IQueryable<MenuEntity> Collection()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }

        public void Delete(string Id)
        {
            throw new NotImplementedException();
        }

        public MenuEntity Find(string Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(MenuEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Update(MenuEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
