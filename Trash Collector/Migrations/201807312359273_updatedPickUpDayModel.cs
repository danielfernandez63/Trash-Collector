namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedPickUpDayModel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "PickupId" });
            CreateIndex("dbo.Customers", "PickUpId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Customers", new[] { "PickUpId" });
            CreateIndex("dbo.Customers", "PickupId");
        }
    }
}
