namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Price = c.Boolean(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        Type_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuType", t => t.Type_ID)
                .Index(t => t.Type_ID);
            
            CreateTable(
                "dbo.MenuType",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SpecialMenu",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Descriptions = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Menu", "Type_ID", "dbo.MenuType");
            DropIndex("dbo.Menu", new[] { "Type_ID" });
            DropTable("dbo.SpecialMenu");
            DropTable("dbo.MenuType");
            DropTable("dbo.Menu");
        }
    }
}
