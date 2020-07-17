using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class Menus
    {
        
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("MenuTypeID")]
        public MenuType Type { get; set; }
        public string MenuTypeID { get; set; }
        public string Image { get; set; }
        public string menuList { get; set; }
    }
}