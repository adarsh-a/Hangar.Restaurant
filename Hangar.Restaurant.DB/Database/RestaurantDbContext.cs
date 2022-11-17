using Hangar.Restaurant.Database.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Hangar.Restaurant.Database
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext() : base("DefaultConnection")
        {
        }
        public DbSet<MenuSectionEntity> MenuSection { get; set; }

        public DbSet<CustomerEntity> Customer { get; set; }

        public DbSet<MenuEntity> Menu { get; set; }

        public DbSet<Order> Order { get; set; }
        public object MenuEntity { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}