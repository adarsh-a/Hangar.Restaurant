using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenuSectionController : Controller
    {
        // GET: MenuSection
        IRepositoryBase<MenusEntity> menuContext;
        IRepositoryBase<MenuSectionEntity> sectionContext;
        public MenuSectionController(IRepositoryBase<MenusEntity> menuCon, IRepositoryBase<MenuSectionEntity> sectionCon)
        {
            menuContext = menuCon;
            sectionContext = sectionCon;
        }
        public ActionResult FetchMenuSection()
        {
            var menuModel = new MenuSection();
            var menuData = sectionContext.Collection().FirstOrDefault();

            List <MenusEntity> menusEntities= menuContext.Collection().Include(x => x.Type).ToList();
            List<Menus> menulist = new List<Menus>();

            if (menuData != null)
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;

            }

            foreach (var item in menusEntities)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    Type = new MenuType() { Name = item.Type.Name.ToLower() }

                });

            }

            var model = new MenusViewModel() { menulistVM = menulist, Description = menuModel.Description, Title = menuModel.Title};
            return PartialView("~/Views/PartialView/Menus.cshtml", model);
        }

    }
}
