using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class MenusController : Controller
    {
        // GET: Menus
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: MenuSection
        public ActionResult FetchMenu()
        {
            var menusModel = new Menus();
            var menusData = db.Menus.FirstOrDefault();
            if (menusData != null)
            {
                menusModel.Name = menusData.Name;
                menusModel.Price = menusData.Price;
                menusModel.Description = menusData.Description;
                menusModel.Image = menusData.Image;
            }
            return View("~/Views/PartialView/Menus.cshtml", menusModel);
        }
    }
}