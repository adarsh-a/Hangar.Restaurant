namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reservation_system : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReservationEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        date = c.DateTime(nullable: false),
                        time = c.DateTime(nullable: false),
                        numberOfPerson = c.Int(nullable: false),
                        name = c.String(),
                        email = c.String(),
                        phoneNumber = c.String(),
                        table_ID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TableEntity", t => t.table_ID)
                .Index(t => t.table_ID);
            
            CreateTable(
                "dbo.TableEntity",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReservationEntity", "table_ID", "dbo.TableEntity");
            DropIndex("dbo.ReservationEntity", new[] { "table_ID" });
            DropTable("dbo.TableEntity");
            DropTable("dbo.ReservationEntity");
        }
    }
}
