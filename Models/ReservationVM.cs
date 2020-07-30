using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Models
{
    public class ReservationVM
    {
        public Reservation reservation { get; set; }
        public IEnumerable<SelectListItem> numOfPers { get; set; }
    }
}