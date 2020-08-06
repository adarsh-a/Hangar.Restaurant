namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class combine_date_time : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReservationEntity", "dateAndTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReservationEntity", "date");
            DropColumn("dbo.ReservationEntity", "time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReservationEntity", "time", c => c.DateTime(nullable: false));
            AddColumn("dbo.ReservationEntity", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.ReservationEntity", "dateAndTime");
        }
    }
}
