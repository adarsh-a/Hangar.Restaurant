using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
            //here for testing.. will change it tomorrow
            MailAddress from = new MailAddress("info@mail.restaurant");
            MailAddress to = new MailAddress("alex.lacour@hangarww.com");
            MailMessage message = new MailMessage(from, to);
            message.Subject = "A subject to this";
            message.Body = "Another body here is the body";

            SmtpClient smtp = new SmtpClient();
            smtp.Send(message);

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


            int tableId;
            var specificEntities = reservationContext.Collection().Where(ent => ent.date == (DateTime)form.date && ent.time == (DateTime)form.time)
                .ToList();

            if (specificEntities.Count() != 0)
            {
                tableId = specificEntities.Select(ent => ent.tableId).ToList().Max() + 1;
            }
            else
            {
                tableId = 1;
            }


            if (tableId > 10)
            {
                //cannot book at that date and time
                ViewBag.booked = false;
                ViewBag.msg = "No table available on that specific date and time";

                return View(form);
            }

            //not necessary to put ID as it auto increments in DB
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

        public static void sendEmail()
        {
            Console.WriteLine("ds");
            Console.ReadLine();
        }

 
    }
}