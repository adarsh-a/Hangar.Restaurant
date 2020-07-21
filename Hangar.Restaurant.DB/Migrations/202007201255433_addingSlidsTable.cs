namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingSlidsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SlideshowEntity",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        title = c.String(),
                        description = c.String(),
                        image = c.String(),
                        links = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SlideshowEntity");
        }
    }
}
