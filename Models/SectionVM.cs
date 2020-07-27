using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class SectionVM
    {
        public List<Menu> menuList { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<MenuType> typeList { get; set; }
        public int menuLength { get; set; }
    }
}