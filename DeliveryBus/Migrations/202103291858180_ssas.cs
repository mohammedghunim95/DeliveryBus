namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ssas : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ApplyTrips", "Subscribe", c => c.Double(nullable: false));
            AlterColumn("dbo.ApplyTrips", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ApplyTrips", "Price", c => c.String());
            AlterColumn("dbo.ApplyTrips", "Subscribe", c => c.String());
        }
    }
}
