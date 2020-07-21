namespace Hangar.Restaurant.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sliders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SliderEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Description1 = c.String(),
                        Image = c.String(),
                        Links = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SliderEntity");
        }
    }
}
