using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenuController : Controller
    {
        private RestaurantDbContext context = new RestaurantDbContext();

        // GET: Menu
        public ActionResult FecthMenu()
        {
            var menus = context.Menus.SqlQuery("SELECT * FROM MenuEntity").ToList();
            List<Menu> menuModel = new List<Menu>();

            if(menus == null)
             {
                return HttpNotFound();
            }
            foreach(var item in menus)
            {
                menuModel.Add(new Menu() {Name = item.Name, Description = item.Description, 
                    Price = item.Price, Image = item.Image, MenuTypeId = item.MenuTypeId });
            }

            return View(menuModel);
        }
    }
}