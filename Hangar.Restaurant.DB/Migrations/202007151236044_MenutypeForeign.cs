namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MenutypeForeign : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MenusEntity", name: "MenuId_ID", newName: "MenuTypeID");
            RenameIndex(table: "dbo.MenusEntity", name: "IX_MenuId_ID", newName: "IX_MenuTypeID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MenusEntity", name: "IX_MenuTypeID", newName: "IX_MenuId_ID");
            RenameColumn(table: "dbo.MenusEntity", name: "MenuTypeID", newName: "MenuId_ID");
        }
    }
}
