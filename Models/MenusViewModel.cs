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
        public string Descriptions { get; set; }
        public List<MenuType> menuTypesList { get; set; }
        //public int countMenu { get; set; }
        public bool flagElement {get; set;}
    }
}