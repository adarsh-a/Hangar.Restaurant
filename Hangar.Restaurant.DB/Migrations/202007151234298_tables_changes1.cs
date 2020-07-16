namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_changes1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.MenuEntity", name: "Type_ID", newName: "MenuTypeId");
            RenameIndex(table: "dbo.MenuEntity", name: "IX_Type_ID", newName: "IX_MenuTypeId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.MenuEntity", name: "IX_MenuTypeId", newName: "IX_Type_ID");
            RenameColumn(table: "dbo.MenuEntity", name: "MenuTypeId", newName: "Type_ID");
        }
    }
}
