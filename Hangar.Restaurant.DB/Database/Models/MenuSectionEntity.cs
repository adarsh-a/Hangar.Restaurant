using System.ComponentModel.DataAnnotations;

namespace Hangar.Restaurant.Database.Models
{
    public class MenuSectionEntity
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
}