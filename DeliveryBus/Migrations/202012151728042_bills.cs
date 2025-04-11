namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bills : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillDets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillId = c.Int(nullable: false),
                        MealId = c.Int(nullable: false),
                        Qty = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Bills");
            DropTable("dbo.BillDets");
        }
    }
}
