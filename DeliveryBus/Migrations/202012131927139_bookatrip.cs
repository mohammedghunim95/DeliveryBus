namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookatrip : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ApplyTrips",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Message = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        RegionId = c.Int(nullable: false),
                        UserId = c.String(),
                        applicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.applicationUser_Id)
                .ForeignKey("dbo.Regions", t => t.RegionId, cascadeDelete: true)
                .Index(t => t.RegionId)
                .Index(t => t.applicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplyTrips", "RegionId", "dbo.Regions");
            DropForeignKey("dbo.ApplyTrips", "applicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.ApplyTrips", new[] { "applicationUser_Id" });
            DropIndex("dbo.ApplyTrips", new[] { "RegionId" });
            DropTable("dbo.ApplyTrips");
        }
    }
}
