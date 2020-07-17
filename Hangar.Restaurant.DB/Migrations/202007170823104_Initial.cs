namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MenusEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Image = c.String(),
                        TypeId_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MenuTypeEntity", t => t.TypeId_Id)
                .Index(t => t.TypeId_Id);
            
            CreateTable(
                "dbo.MenuTypeEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.SpecialMenuEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenusEntity", "TypeId_Id", "dbo.MenuTypeEntity");
            DropIndex("dbo.MenusEntity", new[] { "TypeId_Id" });
            DropTable("dbo.SpecialMenuEntity");
            DropTable("dbo.MenuSectionEntity");
            DropTable("dbo.MenuTypeEntity");
            DropTable("dbo.MenusEntity");
        }
    }
}
