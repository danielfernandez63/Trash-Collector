namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Employees", new[] { "ApplicationUserId" });
            DropColumn("dbo.Employees", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Employees", "ApplicationUserId");
            AddForeignKey("dbo.Employees", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
