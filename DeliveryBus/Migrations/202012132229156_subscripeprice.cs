namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class subscripeprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplyTrips", "Price", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplyTrips", "Price");
        }
    }
}
