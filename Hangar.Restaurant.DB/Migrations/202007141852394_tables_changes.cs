namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tables_changes : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Menu", newName: "MenuEntity");
            RenameTable(name: "dbo.MenuType", newName: "MenuTypeEntity");
            RenameTable(name: "dbo.SpecialMenu", newName: "SpecialMenuEntity");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SpecialMenuEntity", newName: "SpecialMenu");
            RenameTable(name: "dbo.MenuTypeEntity", newName: "MenuType");
            RenameTable(name: "dbo.MenuEntity", newName: "Menu");
        }
    }
}
