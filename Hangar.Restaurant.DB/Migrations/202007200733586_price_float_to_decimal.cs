namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class price_float_to_decimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuEntity", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuEntity", "Price", c => c.Double(nullable: false));
        }
    }
}
