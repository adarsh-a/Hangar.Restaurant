using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hangar.Restaurant.Models
{
    public class MenuEntity
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        [ForeignKey("MenuTypeId")]
        public MenuTypeEntity Type { get; set; }
        public string MenuTypeId { get; set; }
    }
}   