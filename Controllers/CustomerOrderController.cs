using Hangar.Restaurant.Database;
using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Order = Hangar.Restaurant.Database.Models.Order;

namespace Hangar.Restaurant.Controllers
{
    public class CustomerOrderController : Controller
    {
        private RestaurantDbContext db = new RestaurantDbContext();

        // GET: CustomerOrder
        public ActionResult Index(string FirstName, string LastName)
        {
            var customers = from c in db.Customer
                            orderby c.Id
                            select c;
            return View(customers);
        }



        public ActionResult PlaceOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PlaceOrder(string FirstName, string LastName)
        {

            var cust = db.Customer.Find(FirstName,LastName);
            //if customer does not exists, create customer
            //var customerr = Index(FirstName, LastName);
            string currentId= Guid.NewGuid().ToString();

            if (cust == null)
            {
                try
                {

                    db.Customer.Add(new CustomerEntity()
                    {
                        Id = currentId,
                        FirstName = FirstName,
                        LastName=LastName

                    });

                    db.SaveChanges();                    




                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Cannot place order');</script>");
                }
            }
            else
            {

                //RETURN Id
                currentId = cust.Id;


            }

            //insert order
            InsertOrder(currentId);

            return View();

        }




        public ActionResult InsertOrder(string CustomerId)
        {

            //List<Order> order = new List<Order>();

            //var ord = db.Order.Find(oid);
            //if customer does not exists, create customer
            //var orderr = FetchOrderDetailsByCId(CustomerId,OrderDetails,OrderedDate,TotalPrice);

            if (Session["cart"] != null)
            {

               

               var cartSession = (List<Menu>)Session["cart"];

                var orderEntity = new Order();
                orderEntity.OrderDetails = JsonConvert.SerializeObject(cartSession);
                orderEntity.CustomerId = CustomerId;
                orderEntity.OrderedDate = DateTime.Now;
                orderEntity.TotalPrice = TotalPrice(cartSession);  //calculate total based on cart in session

                try
                {
                    db.Order.Add(orderEntity);
                    db.SaveChanges();
                }

                catch (Exception ex) 
                {
                
                
                }

            }
            else
            {

                // nothin in cart
            
            
            }

           


          


            return View();

        }



        public int TotalPrice(List<Menu> SessionCart) {



            var total=0;
            var menuEntities = from m in db.Menu orderby m.Id select m;
            foreach ( var MenuItem in SessionCart )
            {
                var dbMenu = menuEntities.FirstOrDefault(i => i.Id == MenuItem.Id);

                if (dbMenu != null) {
                    total = total + (dbMenu.MealPrice * MenuItem.Quantity);
                
                
                }


            }
            return total;

        }




        public ActionResult FetchOrderDetailsByCId()
        {



            var fetchorders ="";
                             // join c in db.Customer on o.CustomerId equals Order.Id
                             // where c.Id == Order.CustomerId
                             // select o.SingleOrDefault();
            return View(fetchorders);

        }










    }

}