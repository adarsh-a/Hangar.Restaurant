namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation_system_up : DbMigration
    {
        public override void Up()
        {
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
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TableEntity", t => t.tableId, cascadeDelete: true)
                .Index(t => t.tableId);
            
            CreateTable(
                "dbo.TableEntity",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationEntity", "tableId", "dbo.TableEntity");
            DropIndex("dbo.ReservationEntity", new[] { "tableId" });
            DropTable("dbo.TableEntity");
            DropTable("dbo.ReservationEntity");
        }
    }
}
