namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table_banner : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannerEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        ButtonName = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BannerEntity");
        }
    }
}
