using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class LoadMore
    {
        public bool ShowLoadMore { get; set; }
        public List<Menus> Menus { get; set; }
    }
}