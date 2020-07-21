using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Database.Models
{
    public class BannerEntity
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Link { get; set; }
        public string ButtonName { get; set; }
        public string Image { get; set; }
    }
}
