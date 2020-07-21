using Hangar.Restaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.ViewModels
{
    public class MenuViewModel
    {
        internal object name;
        public List<Menus> menus { get; set; }
        public List<MenuType> menuType { get; set; }
        public List<Slider> sliders { get; set; }
        public List<SpecialMenus> specialMenus { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}