namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Modification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SliderEntity", "Description1", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SliderEntity", "Description1");
        }
    }
}
