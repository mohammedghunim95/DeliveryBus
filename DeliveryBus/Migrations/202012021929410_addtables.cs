namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BusCompanies",
                c => new
                    {
                        BusCompanyId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BusCompanyId);
            
            CreateTable(
                "dbo.BusLines",
                c => new
                    {
                        BusLinesId = c.Int(nullable: false, identity: true),
                        Line = c.String(nullable: false),
                        Gate = c.String(nullable: false),
                        BusCompanyId = c.Int(nullable: false),
                        BusTimeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BusLinesId)
                .ForeignKey("dbo.BusCompanies", t => t.BusCompanyId, cascadeDelete: true)
                .ForeignKey("dbo.BusTimes", t => t.BusTimeId, cascadeDelete: true)
                .Index(t => t.BusCompanyId)
                .Index(t => t.BusTimeId);
            
            CreateTable(
                "dbo.BusTimes",
                c => new
                    {
                        BusTimeId = c.Int(nullable: false, identity: true),
                        Times = c.String(nullable: false),
                        Days = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.BusTimeId);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Time = c.String(nullable: false),
                        BusLinesId = c.Int(nullable: false),
                        BusTime_BusTimeId = c.Int(),
                    })
                .PrimaryKey(t => t.RegionId)
                .ForeignKey("dbo.BusLines", t => t.BusLinesId, cascadeDelete: true)
                .ForeignKey("dbo.BusTimes", t => t.BusTime_BusTimeId)
                .Index(t => t.BusLinesId)
                .Index(t => t.BusTime_BusTimeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Regions", "BusTime_BusTimeId", "dbo.BusTimes");
            DropForeignKey("dbo.Regions", "BusLinesId", "dbo.BusLines");
            DropForeignKey("dbo.BusLines", "BusTimeId", "dbo.BusTimes");
            DropForeignKey("dbo.BusLines", "BusCompanyId", "dbo.BusCompanies");
            DropIndex("dbo.Regions", new[] { "BusTime_BusTimeId" });
            DropIndex("dbo.Regions", new[] { "BusLinesId" });
            DropIndex("dbo.BusLines", new[] { "BusTimeId" });
            DropIndex("dbo.BusLines", new[] { "BusCompanyId" });
            DropTable("dbo.Regions");
            DropTable("dbo.BusTimes");
            DropTable("dbo.BusLines");
            DropTable("dbo.BusCompanies");
        }
    }
}
