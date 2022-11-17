using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangar.Restaurant.Database.Models
{
    public class CustomerEntity
    {
        public string Id { get; set; }
        [Key, Column(Order = 0)]
        public string FirstName { get; set; }
        [Key, Column(Order = 1)]
        public string LastName { get; set; }



  
    }
}
