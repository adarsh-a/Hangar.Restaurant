using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenuEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public bool Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public MenuTypeEntity Type { get; set; }
    }
}   