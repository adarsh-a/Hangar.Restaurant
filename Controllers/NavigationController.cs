using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Nav
        public PartialViewResult Index()
        {
            //get parent controller name to display on banner
            string control = ViewBag.controller = ControllerContext.ParentActionViewContext.RouteData.Values["controller"].ToString();

            if(control == "Reservation" || control == "Stuff" || control == "Gallery")
            {
                ViewBag.dropactive = "active";
            }
            else if(control == "Menu")
            {
                ViewBag.menuactive = "active";
            }
            return PartialView();
        }
    }
}