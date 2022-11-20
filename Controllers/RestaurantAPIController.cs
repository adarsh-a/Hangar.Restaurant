using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class RestaurantAPIController : Controller
    {

        public string Get()
        {


            return "OK";
           /* var order = new Customer {FirstName="Menisha",LastName="Jugoo"};
             
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
           */
                
        }



    }
}