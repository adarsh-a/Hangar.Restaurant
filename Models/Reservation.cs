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
        [Required(ErrorMessage = "Enter a date")]
        public DateTime? date { get; set; }
        [Required(ErrorMessage = "Enter a time")]
        public DateTime? time { get; set; }
        [Required(ErrorMessage = "Select a number of person")]
        [Range(1,7,ErrorMessage ="Select a number of person")]
        public int numberOfPerson { get; set; }
        [Required(ErrorMessage = "Enter your name")]
        public string name { get; set; }
        [Required(ErrorMessage = "Enter your email")]
        public string email { get; set; }
        [Required(ErrorMessage = "Enter your phone number")]
        public string phoneNumber { get; set; }
        [ForeignKey("tableId")]
        public Table table { get; set; }
        public string tableId { get; set; }
    }
}