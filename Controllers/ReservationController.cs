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
        }

        // GET: Reservation
        public ActionResult Index()
        {

            return View();
        }
        
        [HttpPost]
        [AllowAnonymous]
        [WebMethod]
        public async Task<JsonResult> Reservation(string[] reservationForm)
        {
            ReservationEntity entity = new ReservationEntity();

            DateTime reservationDate = DateTime.Parse(reservationForm[0]);
            DateTime reservationTime = DateTime.Parse(reservationForm[1]);
            DateTime reservationDateTime = new DateTime(
                reservationDate.Year,
                reservationDate.Month,
                reservationDate.Day,
                reservationTime.Hour,
                reservationTime.Minute,
                reservationTime.Second);
            int tableId;
            int TABLELIMIT = 10;
            // message to display to user with specific boostrap color
            string color, msg;

            // check date and time of reservation
            if (reservationDateTime <= DateTime.Now)
            {
                color = "text-danger";
                msg = "Cannot book in the past";

                return Json(new { color, msg });

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
                    color = "text-danger";
                    msg = "No table available on that specific date and time";

                    return Json(new { color, msg });
                }
            }
            else
            {
                tableId = 1;
            }

            //assign all to their specific constructor on entity
            entity.dateAndTime = reservationDateTime;
            entity.numberOfPerson = int.Parse(reservationForm[2]);
            entity.name = reservationForm[3];
            entity.email = reservationForm[4];
            entity.phoneNumber = reservationForm[5];
            entity.tableId = tableId;

            reservationContext.Insert(entity);
            reservationContext.Commit();

            // send confirmation mail
            await mailcontext.ReservationAsync(entity.email, entity.name, entity.dateAndTime, entity.numberOfPerson);

            // Show successful message to user
            color = "text-success";
            msg = "Your reservation was done successfully.<br>You will soon get an email";

            return Json(new { color, msg });
        }
    }
}