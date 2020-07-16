using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
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
        private RestaurantDbContext db = new RestaurantDbContext();
        public ActionResult fetchMenus()
        {
            var menuModel = new MenusViewModel();
            var menuData = db.Menus.SqlQuery("SELECT * from MenusEntity").ToList();
            List<Menus> menulist = new List<Menus>();

            /* if (menuData != null)
             {
                 menuModel.Name = menuData.Name;
                 menuModel.Description = menuData.Description;
             }*/

            //menulist.Add(new Menus())
            foreach(var item in menuData)
            {
                menulist.Add(new Menus { Name = item.Name, Description = item.Description, Image = item.Image });
            }
            
            return View(menulist);
        }
    }
}