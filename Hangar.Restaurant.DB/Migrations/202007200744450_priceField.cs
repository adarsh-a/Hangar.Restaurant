namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class priceField : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenusEntity", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenusEntity", "Price", c => c.Double(nullable: false));
        }
    }
}
