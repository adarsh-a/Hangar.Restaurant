using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenusViewModel : Menus
    {
        //IEnumerable<Menus> IenumerableMenus{ get; set; }
        public List<Menus> menulistVM { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}