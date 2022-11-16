using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.Database.Models
{
    public class MenuEntity
    {
        public int Id { get; set; }
        public string MealName { get; set; }
        public string MealPrice { get; set; }
    }
}
