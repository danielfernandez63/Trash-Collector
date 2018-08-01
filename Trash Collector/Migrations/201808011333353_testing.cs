namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testing : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "ApplicationUserId" });
            DropColumn("dbo.Customers", "ApplicationUserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Customers", "ApplicationUserId");
            AddForeignKey("dbo.Customers", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
    }
}
