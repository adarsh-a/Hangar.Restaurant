namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LinkNameBanner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BannerSectionEntity", "LinkName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BannerSectionEntity", "LinkName");
        }
    }
}
