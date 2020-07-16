using Hangar.Restaurant.Database;
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

        // GET: MenuSection
        public ActionResult FetchMenuSection()
        {
            

            var menuModel = new MenuSection();
            var menuData = db.MenuSection.FirstOrDefault();

            var menus = db.Menus.Include(x => x.Type).ToList();
            List<Menu> menuListModel = new List<Menu>();

   

            if (menuData != null) 
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;
            
            }

            foreach (var item in menus)
            {
                
                menuListModel.Add(new Menu()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Type = new MenuType() { name = item.Type.name}

                }); ;
            }

            SectionVM model = new SectionVM() { menuList = menuListModel, Title = menuModel.Title, Description = menuModel.Description };

            return View("~/Views/PartialView/Menus.cshtml", model);
        }

        
    }
}