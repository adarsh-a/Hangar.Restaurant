using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hangar.Restaurant.Models
{
    public class Reservation
    {
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public int numberOfPerson { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        [ForeignKey("tableId")]
        public Table table { get; set; }
        public string tableId { get; set; }
    }
}