using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.DB.Database.Models
{
    public class SliderEntity
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public string Image { get; set; }
        public string Links { get; set; }
    }
}
