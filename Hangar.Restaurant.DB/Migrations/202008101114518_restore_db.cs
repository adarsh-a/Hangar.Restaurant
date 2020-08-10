namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class restore_db : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.BannerEntity", newName: "BannerEntities");
            RenameTable(name: "dbo.MenuEntity", newName: "MenuEntities");
            RenameTable(name: "dbo.MenuTypeEntity", newName: "MenuTypeEntities");
            RenameTable(name: "dbo.MenuSectionEntity", newName: "MenuSectionEntities");
            RenameTable(name: "dbo.ReservationEntity", newName: "ReservationEntities");
            RenameTable(name: "dbo.TableEntity", newName: "TableEntities");
            RenameTable(name: "dbo.SpecialMenuEntity", newName: "SpecialMenuEntities");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SpecialMenuEntities", newName: "SpecialMenuEntity");
            RenameTable(name: "dbo.TableEntities", newName: "TableEntity");
            RenameTable(name: "dbo.ReservationEntities", newName: "ReservationEntity");
            RenameTable(name: "dbo.MenuSectionEntities", newName: "MenuSectionEntity");
            RenameTable(name: "dbo.MenuTypeEntities", newName: "MenuTypeEntity");
            RenameTable(name: "dbo.MenuEntities", newName: "MenuEntity");
            RenameTable(name: "dbo.BannerEntities", newName: "BannerEntity");
        }
    }
}
