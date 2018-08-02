namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedlastone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CompletePickUp", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "SuspendService");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SuspendService", c => c.Boolean(nullable: false));
            DropColumn("dbo.Customers", "CompletePickUp");
        }
    }
}
