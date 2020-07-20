using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MultipleData
    {
        internal object name;

        public List<MenuList> menuList { get; set; }
        public List<MenuType> menutype { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}