namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodelCustomer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "PickUpDay", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "PickUpDay", c => c.String());
        }
    }
}
