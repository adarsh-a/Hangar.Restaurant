using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hangar.Restaurant.Database
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("RestaurantDbContext")
        {
        }
        public DbSet<MenuSectionEntity> MenuSection { get; set; }
        public DbSet<MenuTypeEntity> MenuTypes { get; set; }
        public DbSet<MenusEntity> Menus { get; set; }
        public DbSet<SpecialMenusEntity> SpecialMenus { get; set; }
 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}