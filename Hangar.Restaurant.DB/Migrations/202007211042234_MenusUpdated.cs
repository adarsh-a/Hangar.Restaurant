namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenusUpdated : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenusEntity", "TypeId_Id", "dbo.MenuTypeEntity");
            DropIndex("dbo.MenusEntity", new[] { "TypeId_Id" });
            RenameColumn(table: "dbo.MenusEntity", name: "TypeId_Id", newName: "TypeId");
            AlterColumn("dbo.MenusEntity", "TypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.MenusEntity", "TypeId");
            AddForeignKey("dbo.MenusEntity", "TypeId", "dbo.MenuTypeEntity", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenusEntity", "TypeId", "dbo.MenuTypeEntity");
            DropIndex("dbo.MenusEntity", new[] { "TypeId" });
            AlterColumn("dbo.MenusEntity", "TypeId", c => c.Int());
            RenameColumn(table: "dbo.MenusEntity", name: "TypeId", newName: "TypeId_Id");
            CreateIndex("dbo.MenusEntity", "TypeId_Id");
            AddForeignKey("dbo.MenusEntity", "TypeId_Id", "dbo.MenuTypeEntity", "Id");
        }
    }
}
