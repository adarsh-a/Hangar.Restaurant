using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Database.Models
{
    public class SlideshowEntity
    {
        [Key]
        public string Id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string links { get; set; }
    }
}
