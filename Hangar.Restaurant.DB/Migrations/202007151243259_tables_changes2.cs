namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_changes2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MenuEntity", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MenuEntity", "Price", c => c.Boolean(nullable: false));
        }
    }
}
