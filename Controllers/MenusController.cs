using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;


namespace Hangar.Restaurant.Controllers
{
    public class MenusController : Controller
    {
        // GET: Menus
        //private RestaurantDbContext db = new RestaurantDbContext();
        IRepositoryBase<Menus> menuContext;
        IRepositoryBase<MenuSection> sectionContext;
        public MenusController(IRepositoryBase<Menus> menuCon, IRepositoryBase<MenuSection> sectionCon)
        {
            menuContext = menuCon;
            sectionContext = sectionCon;
        }
        public ActionResult fetchMenus()
        {

            var menuModel = new MenuSection();
            var menuData = sectionContext.Collection().FirstOrDefault();
            
            var menudata = menuContext.Collection().Include(x=>x.Type).ToList() ;
            List<Menus> menulist = new List<Menus>();

            if (menuData != null)
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;

            }

           foreach (var item in menulist)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price = item.Price,
                    Type = new MenuType() { Name = item.Type.Name }
                });

            }
            
            var model = new MenusViewModel() { menulistVM = menulist, Description = menuModel.Description, Title = menuModel.Title };
            return View("~/Views/PartialView/Menus.cshtml", model);
        }


    }
    
}