namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreign_key_added : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ReservationEntity", name: "table_ID", newName: "tableId");
            RenameIndex(table: "dbo.ReservationEntity", name: "IX_table_ID", newName: "IX_tableId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ReservationEntity", name: "IX_tableId", newName: "IX_table_ID");
            RenameColumn(table: "dbo.ReservationEntity", name: "tableId", newName: "table_ID");
        }
    }
}
