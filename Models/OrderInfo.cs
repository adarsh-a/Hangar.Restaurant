using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class OrderInfo
    {

        public Customer CustomerDetails { set; get; }


        public Order OrderDetails { set; get; }

    }

}