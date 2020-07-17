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
        public ActionResult FetchMenu()
        {
            var menusModel = new Menus();
            var menusData = db.Menus.ToList();
            return View("~/Views/PartialView/Menus.cshtml", menusData);
        }
    }
}