using Hangar.Restaurant.Database;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.DB.Repo;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenusController : Controller
    {
        // GET: Menus
        private RestaurantDbContext db = new RestaurantDbContext();
        private IRepository<MenusEntity> menusContext;
        private IRepository<MenuTypeEntity> menuTypeContext;
        private IRepository<SpecialMenuEntity> specialMenuContext;
        public MenusController(IRepository<MenusEntity> Context , IRepository<MenuTypeEntity> typeContext , IRepository<SpecialMenuEntity> specialContext )
        {
            menusContext = Context;
            menuTypeContext = typeContext;
            specialMenuContext = specialContext;
        }
        public ActionResult FetchMenu()
        {
            MenuType menuType = new MenuType();
            SpecialMenu specialMenu = new SpecialMenu();
            SpecialMenuEntity menusData = specialMenuContext.Collection().FirstOrDefault();

            List<MenusEntity> menuList = menusContext.Collection().Include(ent => ent.Type).ToList();
            List<MenuTypeEntity> menuTypeList = menuTypeContext.Collection().ToList();
            List<Menus> menusModel = new List<Menus>();
            List<MenuType> menuTypeModel = new List<MenuType>();

            if (menusData != null)
            {
                specialMenu.Title = menusData.Title;
                specialMenu.Description = menusData.Description;

            }

            foreach (var item in menuList)
            {
                menusModel.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Type = new MenuType() { Name = item.Type.Name}
                });
            }

            foreach(var type in menuTypeList)
            {
                menuTypeModel.Add(new MenuType()
                {
                    Name = type.Name
                });
            }

            MenuViewModel viewModel = new MenuViewModel()
            {
                menus = menusModel,
                menuType = menuTypeModel,
                name = menuType.Name,
                Title = specialMenu.Title,
                Description = specialMenu.Description

            };

            //var menusModel = new Menus();
            //var menusData = db.Menus.ToList();
            return PartialView("~/Views/PartialView/Menus.cshtml", viewModel);
        }
    }
}