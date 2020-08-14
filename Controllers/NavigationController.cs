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
            string active = "active";

            if(control == "Reservation" || control == "Stuff" || control == "Gallery")
            {
                ViewBag.dropActive = active;
            }
            else if(control == "Menu")
            {
                ViewBag.menuActive = active;
            }
            else if(control == "Home")
            {
                ViewBag.homeActive = active;
            }
            else if(control == "Dashboard")
            {
                @ViewBag.dashActive = active;
            }
            return PartialView("~/Views/Shared/Navigation.cshtml");
        }
    }
}