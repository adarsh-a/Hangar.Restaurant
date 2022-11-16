using Hangar.Restaurant.Database;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: Customer

        public ActionResult Index()
        {
            var customers = from c in db.Customer
                            orderby c.Id
                            select c;
            return View(customers);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Customer cust)
        {
            //var customer = FetchCustomer();
            var customer = Index();

            //check db, if cust exists,
            //return customer id
            //else create customer
            //then return customer id 

           




            return View();
        }








    }
}
