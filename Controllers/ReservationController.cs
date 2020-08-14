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
        private IMail mailcontext;

        public ReservationController(IRepositoryBase<ReservationEntity> reservationCon, IRepositoryBase<TableEntity> tableCon, IMail mailCon)
        {
            reservationContext = reservationCon;
            tableContext = tableCon;
            mailcontext = mailCon;

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
            await mailcontext.ReservationAsync(entity.email, entity.name, entity.dateAndTime, entity.numberOfPerson);

            // Show successful message to user
            ViewBag.color = "text-success";
            ViewBag.msg = "Your reservation was done successfully.<br>You will soon get an email";

            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public JsonResult Reservation()
        {
            string he = "hello";

            return Json(new { he });
        }
    }
}