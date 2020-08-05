﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class Menu
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("MenuTypeId")]
        public MenuType Type { get; set; }
        [DisplayName("Menu Type")]
        public string MenuTypeId { get; set; }
    }
    
}   