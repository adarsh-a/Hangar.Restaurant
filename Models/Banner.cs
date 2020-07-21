using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class Banner
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ButtonName { get; set; }
        public string Image { get; set; }
    }
}