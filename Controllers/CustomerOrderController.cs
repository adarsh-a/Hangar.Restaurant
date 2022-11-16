using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class CustomerOrderController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: CustomerOrder
        public ActionResult AddToCart(int itemId)
        {
            if (Session["cart"] == null)
            {



                List<Menu> cart = new List<Menu>();
                var menuitem = db.Menu.Find(itemId);
                cart.Add(new Menu()
                {
                    Id = menuitem.Id,
                    Quantity = 1
                });
                Session["cart"] = cart;
            }


            else
            {


                List<Menu> cart = (List<Menu>) Session["cart"];
                var menuitem = db.Menu.Find(itemId);
                cart.Add(new Menu()
                {
                    Id = itemId,
                    Quantity = 1
                });
                Session["cart"] = cart;


            }
            return View();
        }
    }
}