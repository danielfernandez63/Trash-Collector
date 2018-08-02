namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBoolForPickUp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "SuspendService", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SuspendService");
        }
    }
}
