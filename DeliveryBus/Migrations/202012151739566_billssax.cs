namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class billssax : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillDets", "RegionId", c => c.Int(nullable: false));
            AlterColumn("dbo.BillDets", "Qty", c => c.Double(nullable: false));
            DropColumn("dbo.BillDets", "MealId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillDets", "MealId", c => c.Int(nullable: false));
            AlterColumn("dbo.BillDets", "Qty", c => c.Int(nullable: false));
            DropColumn("dbo.BillDets", "RegionId");
        }
    }
}
