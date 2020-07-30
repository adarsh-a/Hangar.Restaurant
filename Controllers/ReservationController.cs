using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace Hangar.Restaurant.Controllers
{
    public class ReservationController : Controller
    {
        private IRepositoryBase<ReservationEntity> reservationContext;
        private IRepositoryBase<TableEntity> tableContext;

        public ReservationController(IRepositoryBase<ReservationEntity> reservationCon, IRepositoryBase<TableEntity> tableCon)
        {
            reservationContext = reservationCon;
            tableContext = tableCon;
        }

        // GET: Reservation
        public ActionResult Index()
        {

            ReservationVM model = new ReservationVM();
            model.numOfPers = new List<SelectListItem>() {
                new SelectListItem() { Text = "Select Person", Disabled = true},
                new SelectListItem() { Text = "1", Value = 1.ToString()},
                new SelectListItem() { Text = "2", Value = 2.ToString()},
                new SelectListItem() { Text = "3", Value = 3.ToString()},
                new SelectListItem() { Text = "4", Value = 4.ToString()},
                new SelectListItem() { Text = "5", Value = 5.ToString()},
                new SelectListItem() { Text = "6", Value = 6.ToString()},
                new SelectListItem() { Text = "7", Value = 7.ToString()},
        };
           
            

            return View(model);
        }

        [HttpPost]
        [WebMethod]
        [AllowAnonymous]
        public JsonResult bookFreeTable()
        {
            return Json(new { });
        }

        //controller -- 
    }
}