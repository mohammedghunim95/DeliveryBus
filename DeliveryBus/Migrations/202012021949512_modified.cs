namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modified : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Regions", "BusTime_BusTimeId", "dbo.BusTimes");
            DropIndex("dbo.Regions", new[] { "BusTime_BusTimeId" });
            DropColumn("dbo.Regions", "BusTime_BusTimeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Regions", "BusTime_BusTimeId", c => c.Int());
            CreateIndex("dbo.Regions", "BusTime_BusTimeId");
            AddForeignKey("dbo.Regions", "BusTime_BusTimeId", "dbo.BusTimes", "BusTimeId");
        }
    }
}
