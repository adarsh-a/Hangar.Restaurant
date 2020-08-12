using Hangar.Restaurant.Database.Models;
using Hangar.Restaurant.DB.Database.Models;
using Hangar.Restaurant.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hangar.Restaurant.Database
{
    public class RestaurantDbContext : IdentityDbContext<AdminUserEntity>
    {
        public RestaurantDbContext() : base("RestaurantDbContext")
        {

        }

        // Other Dbset
        public DbSet<MenuSectionEntity> MenuSection { get; set; }
        public DbSet<MenuTypeEntity> MenuTypes { get; set; }
        public DbSet<MenuEntity> Menus { get; set; }
        public DbSet<SpecialMenuEntity> SpecialMenus { get; set; }
        public DbSet<BannerEntity> Banners { get; set; }
        public DbSet<ReservationEntity> Reservations { get; set; }
        public DbSet<TableEntity> Tables { get; set; }


        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
    }
}