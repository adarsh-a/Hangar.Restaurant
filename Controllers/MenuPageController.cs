using Hangar.Restaurant.Database;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.DB.Repository;
using Hangar.Restaurant.Models;
using Hangar.Restaurant.ViewModels;
using Microsoft.Ajax.Utilities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Hangar.Restaurant.Controllers
{
    public class MenuPageController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        private IRepository<MenusEntity> menuContext;
        private IRepository<MenuTypeEntity> menuTypeContext;
        private IRepository<SpecialMenusEntity> specialMenuContext;

        public MenuPageController(IRepository<MenusEntity> mContext, IRepository<MenuTypeEntity> mtContext, IRepository<SpecialMenusEntity> smContext)
        {
            menuContext = mContext;
            menuTypeContext = mtContext;
            specialMenuContext = smContext;
        }
        // GET: MenuPage
        public ActionResult MenuLayout()
        {
            SpecialMenus special = new SpecialMenus();
            MenuType menuType = new MenuType();
            SpecialMenusEntity smData = specialMenuContext.Collection().FirstOrDefault();

            //List<MenusEntity> menuList = menuContext.Collection().Include(ent => ent.Type).OrderBy(p => p.Id).Take(9).ToList();
            List<MenusEntity> menuList = menuContext.Collection().Include(t => t.Type).OrderBy(p => p.Id).Take(9).ToList();

            //List<SpecialMenusEntity> specialList = specialMenuContext.Collection().Include(ent => ent.Id).ToList();
            List<MenuTypeEntity> menuTypeList = menuTypeContext.Collection().ToList();
            List<Menus> MenusModel = new List<Menus>();
            List<MenuType> MenuTypeModel = new List<MenuType>();
            List<SpecialMenus> smenuModel = new List<SpecialMenus>();

            int menuCount = menuContext.Collection().Count();

            if (smData != null)
            {
                special.Title = smData.Title;
                special.Description = smData.Description;
            }

            foreach (var item in menuList)
            {
                MenusModel.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Typex = new MenuType() { Name = item.Type.Name }

                });
            }
            foreach (var type in menuTypeList)
            {
                MenuTypeModel.Add(new MenuType()
                {
                    Name = type.Name
                });
            }
            MenuViewModel model = new MenuViewModel()
            {
                menus = MenusModel,
                menuType = MenuTypeModel,
                name = menuType.Name,
                Title = special.Title,
                Description = special.Description
            };
            return PartialView("~/Views/PartialView/MenuPage.cshtml", model);
        }
        public string LoadMore(int count)
        {
            var menuFetch = fetchMenu(count, 9);
            string output = JsonConvert.SerializeObject(menuFetch);
            return output;

        }
        public List<Menus> fetchMenu(int skipCount, int takeCount)
        {
            List<MenusEntity> menuList = menuContext.Collection().Include(t => t.Type).OrderBy(p => p.Id).Take(takeCount).Skip(skipCount).ToList();
            List<MenuTypeEntity> menuTypeList = menuTypeContext.Collection().ToList();
            List<Menus> MenusModel = new List<Menus>();

            foreach (var item in menuList)
            {
                MenusModel.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Price = item.Price,
                    Image = item.Image,
                    Typex = new MenuType() { Name = item.Type.Name }

                });
            }
            return MenusModel;
        }
    }
}