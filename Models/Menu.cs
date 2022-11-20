using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class Menu
    {

        public int Id { get; set; }
        public string MealName { get; set; }
        public int MealPrice { get; set; }
        public int Quantity { get; internal set; }
    }
}