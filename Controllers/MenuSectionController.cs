using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenuSectionController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();
        private IRepositoryBase<MenuEntity> menuContext;
        private IRepositoryBase<MenuSectionEntity> sectionContext;

        public  MenuSectionController(IRepositoryBase<MenuEntity> menuCon, IRepositoryBase<MenuSectionEntity> secCon)
        {
            menuContext = menuCon;
            sectionContext = secCon;
        }

        // GET: MenuSection
        public ActionResult FetchMenuSection()
        {
            

            MenuSection section = new MenuSection();
            MenuSectionEntity menuData = sectionContext.Collection().FirstOrDefault();

            List<MenuEntity> menus = menuContext.Collection().Include(ent => ent.Type).ToList();
            List<Menu> menuListModel = new List<Menu>();

   

            if (menuData != null) 
            {
                section.Title = menuData.Title;
                section.Description = menuData.Description;
            
            }

            foreach (var item in menus)
            {
                
                menuListModel.Add(new Menu()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Type = new MenuType() { name = item.Type.name.ToLower()}

                }); ;
            }

            SectionVM model = new SectionVM() { menuList = menuListModel, Title = section.Title, Description = section.Description };

            return View("~/Views/PartialView/Menus.cshtml", model);
        }

        
    }
}