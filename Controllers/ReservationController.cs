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

            //dropdown list items definition
            ViewBag.selectList = new List<SelectListItem>() {
                new SelectListItem() { Text = "1", Value = "1" },
                new SelectListItem() { Text = "2", Value = "2" },
                new SelectListItem() { Text = "3", Value = "3" },
                new SelectListItem() { Text = "4", Value = "4" },
                new SelectListItem() { Text = "5", Value = "5" },
                new SelectListItem() { Text = "6", Value = "6" },
                new SelectListItem() { Text = "7", Value = "7" },
            };

        }

        // GET: Reservation
        public ActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Index(Reservation form)
        {
            ReservationEntity entity = new ReservationEntity();

            if (!ModelState.IsValid)
            { 
                
                return View(form);
            }


            int id, tableId;
            var allEntity = reservationContext.Collection().ToList();

            if (allEntity.Count != 0)
            {
                id = allEntity.LastOrDefault().ID + 1;
            }
            else
            {
                id = 1;
                tableId = 1;
            }

            var specificEntities = allEntity.Where(ent => ent.date == (DateTime)form.date && ent.time == (DateTime)form.time)
                .ToList();

            if (specificEntities.Count() != 0)
            {
                tableId = specificEntities.Select(ent => ent.tableId).ToList().Max() + 1;
            }
            else
            {
                tableId = 1;
            }
               
            
            if(tableId > 10)
            {
                ViewBag.booked = true;
                ViewBag.msg = "No table available on that specific date and time";

                return View(form);
            }
            
            entity.ID = id;
            entity.name = form.name;
            entity.numberOfPerson = form.numberOfPerson;
            entity.tableId = tableId;
            entity.date = (DateTime)form.date;
            entity.time = (DateTime)form.time;
            entity.phoneNumber = form.phoneNumber;
            entity.email = form.email;

            reservationContext.Insert(entity);
            reservationContext.Commit();

            return RedirectToAction("Index");
        }

 
    }
}