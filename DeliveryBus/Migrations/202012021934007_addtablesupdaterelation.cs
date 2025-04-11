namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtablesupdaterelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "BusTime_BusTimeId", "dbo.BusTimes");
            DropIndex("dbo.Regions", new[] { "BusTime_BusTimeId" });
            RenameColumn(table: "dbo.BusTimes", name: "BusTime_BusTimeId", newName: "RegionId");
            CreateIndex("dbo.BusTimes", "RegionId");
            AddForeignKey("dbo.BusTimes", "RegionId", "dbo.Regions", "RegionId", cascadeDelete: true);
            DropColumn("dbo.Regions", "BusTime_BusTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "BusTime_BusTimeId", c => c.Int());
            DropForeignKey("dbo.BusTimes", "RegionId", "dbo.Regions");
            DropIndex("dbo.BusTimes", new[] { "RegionId" });
            RenameColumn(table: "dbo.BusTimes", name: "RegionId", newName: "BusTime_BusTimeId");
            CreateIndex("dbo.Regions", "BusTime_BusTimeId");
            AddForeignKey("dbo.Regions", "BusTime_BusTimeId", "dbo.BusTimes", "BusTimeId");
        }
    }
}
