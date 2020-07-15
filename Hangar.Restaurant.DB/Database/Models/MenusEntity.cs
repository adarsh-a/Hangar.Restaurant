using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenusEntity
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public MenuTypeEntity MenuId { get; set; }
        public string Image { get; set; }
    }
}