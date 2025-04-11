namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regions", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Price");
        }
    }
}
