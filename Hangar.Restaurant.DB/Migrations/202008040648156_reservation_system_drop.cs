namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation_system_drop : DbMigration
    {
        public override void Up()
        {
            
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TableEntity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ReservationEntity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        date = c.DateTime(nullable: false),
                        time = c.DateTime(nullable: false),
                        numberOfPerson = c.Int(nullable: false),
                        name = c.String(),
                        email = c.String(),
                        phoneNumber = c.String(),
                        tableId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.ReservationEntity", "tableId");
            AddForeignKey("dbo.ReservationEntity", "tableId", "dbo.TableEntity", "ID", cascadeDelete: true);
        }
    }
}
