using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
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
            if (menuData != null) 
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;
            
            }
            return View("~/Views/PartialView/Menus.cshtml", menuModel);
        }
    }
}