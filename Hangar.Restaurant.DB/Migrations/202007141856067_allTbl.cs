namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenusEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                        Image = c.String(),
                        MenuId_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.MenuTypeEntity", t => t.MenuId_ID)
                .Index(t => t.MenuId_ID);
            
            CreateTable(
                "dbo.MenuTypeEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.MenuSectionEntity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SpecialMenusEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenusEntity", "MenuId_ID", "dbo.MenuTypeEntity");
            DropIndex("dbo.MenusEntity", new[] { "MenuId_ID" });
            DropTable("dbo.SpecialMenusEntity");
            DropTable("dbo.MenuSectionEntity");
            DropTable("dbo.MenuTypeEntity");
            DropTable("dbo.MenusEntity");
        }
    }
}
