﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenusEntity
    {
        [Key]

        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("MenuTypeID")] 
        public MenuTypeEntity Type { get; set; }
        public string MenuTypeID { get;set; }
        public string Image { get; set; }
    }
}