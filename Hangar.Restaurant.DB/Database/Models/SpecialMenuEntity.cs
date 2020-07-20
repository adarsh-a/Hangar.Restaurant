using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class SpecialMenuEntity
    {
        [Key]
        public string ID { get; set; }
        public string Title { get; set; }
        public string Descriptions { get; set; }
    }
}