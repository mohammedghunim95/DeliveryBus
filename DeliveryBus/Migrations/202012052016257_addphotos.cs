namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphotos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BusCompanies", "Image", c => c.String());
            AddColumn("dbo.BusLines", "Image", c => c.String());
            AddColumn("dbo.BusTimes", "Image", c => c.String());
            AddColumn("dbo.Regions", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regions", "Image");
            DropColumn("dbo.BusTimes", "Image");
            DropColumn("dbo.BusLines", "Image");
            DropColumn("dbo.BusCompanies", "Image");
        }
    }
}
