namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscripe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyTrips", "Subscribe", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyTrips", "Subscribe");
        }
    }
}
