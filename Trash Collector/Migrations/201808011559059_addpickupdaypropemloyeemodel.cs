namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpickupdaypropemloyeemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "PickUpDay", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "PickUpDay");
        }
    }
}
