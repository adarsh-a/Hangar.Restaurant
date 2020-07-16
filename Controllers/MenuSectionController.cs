using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
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

            //getting data from database
            var menulistData = db.Menus.Include(x=>x.Type).ToList();
            List<Menus> menulist = new List<Menus>();

            if (menuData != null)
            {
                menuModel.Title = menuData.Title;
                menuModel.Description = menuData.Description;

            }


            foreach (var item in menulistData)
            {
                menulist.Add(new Menus()
                {
                    Name = item.Name,
                    Description = item.Description,
                    Image = item.Image,
                    Price= item.Price,
                    Type = new MenuType() { Name= item.Type.Name}
                });

            }
            
            var model = new MenusViewModel() { menulistVM = menulist, Description = menuModel.Description, Title = menuModel.Title };
            return View("~/Views/PartialView/Menus.cshtml", model);
        }

    }
}
