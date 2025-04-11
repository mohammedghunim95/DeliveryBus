namespace DeliveryBus.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adquery : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE AspNetUsers SET Balance=2.00");
        }
        
        public override void Down()
        {
        }
    }
}
