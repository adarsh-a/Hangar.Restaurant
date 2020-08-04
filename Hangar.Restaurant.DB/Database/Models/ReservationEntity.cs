using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Database.Models
{
    public class ReservationEntity
    {
        [Key]
        public int ID { get; set; }
        public DateTime date { get; set; }
        public DateTime time { get; set; }
        public int numberOfPerson { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }
        [ForeignKey("tableId")]
        public TableEntity table { get; set; }
        public int tableId { get; set; }
    }
}
