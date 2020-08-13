using Hangar.Restaurant.Contracts;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
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
        public async Task<ActionResult> Index(Reservation form)
        {
            ReservationEntity entity = new ReservationEntity();

            DateTime reservationDateTime = new DateTime(
                form.date.Year,
                form.date.Month,
                form.date.Day,
                form.time.Hour,
                form.time.Minute,
                form.time.Second);
            int tableId;
            int TABLELIMIT = 10;

            if (!ModelState.IsValid)
            {

                return View(form);
            }

            if (reservationDateTime <= DateTime.Now)
            {
                ViewBag.color = "text-danger";
                ViewBag.msg = "Cannot book in the past";

                return View(form);
            }
            var specificEntities = reservationContext.Collection().Where(ent => ent.dateAndTime == reservationDateTime).ToList();

            // define id for table 
            if (specificEntities.Count() != 0)
            {
                tableId = specificEntities.Select(ent => ent.tableId).ToList().Max() + 1;
                
                // Reserved tables on that specific date and time reaches maximum
                if (tableId > TABLELIMIT)
                {
                    // cannot book at that date and time
                    ViewBag.color = "text-danger";
                    ViewBag.msg = "No table available on that specific date and time";

                    return View(form);
                }
            }
            else
            {
                tableId = 1;
            }


            // not necessary to put ID as it auto increments in DB
            entity.name = form.name;
            entity.numberOfPerson = form.numberOfPerson;
            entity.tableId = tableId;
            entity.dateAndTime = reservationDateTime;
            entity.phoneNumber = form.phoneNumber;
            entity.email = form.email;

            reservationContext.Insert(entity);
            reservationContext.Commit();

            // send confirmation mail
            await sendEmailAsync(entity.email, entity.name, entity.dateAndTime, entity.numberOfPerson);

            // Show successful message to user
            ViewBag.color = "text-success";
            ViewBag.msg = "Your reservation was done successfully.<br>You will soon get an email";

            return View();
        }

        private static async Task sendEmailAsync(string email, string name, DateTime dateAndTime, int person)
        {
            MailAddress from = new MailAddress("info@mail.restaurant");
            MailAddress to = new MailAddress(email);
            MailMessage message = new MailMessage(from, to);
            message.Subject = "Reservation at restaurant";
            message.IsBodyHtml = true;
            message.Body = "<h1>Live Dinner Restaurant<h1><br>" +
                "<h2>Dear Mr/Mrs " + name + ",</h2>" +
                "<h3>A table have been reserved for you. Hereunder are the details:</h3>" +
                "<h4>Name: " + name + "</h4>" +
                "<h4>Date: " + dateAndTime.Day + "/" + dateAndTime.Month + "/" + dateAndTime.Year + "</h4>" +
                "<h4>Time: " + dateAndTime.TimeOfDay + "</h4>" +
                "<h4>No. of person(s): " + person + "</h4>" +
                "<h4>Thank you.</h4>";

            SmtpClient smtp = new SmtpClient();
            await smtp.SendMailAsync(message);
        }

 
    }
}