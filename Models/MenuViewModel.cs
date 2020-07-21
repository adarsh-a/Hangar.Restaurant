using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenuViewModel
    {
        internal object name;
        public List<Menus> menus { get; set; }
        public List<MenuType> menuType { get; set; }
        //public List<Slider> sliders { get; set; }
        public List<SpecialMenu> specialMenus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}