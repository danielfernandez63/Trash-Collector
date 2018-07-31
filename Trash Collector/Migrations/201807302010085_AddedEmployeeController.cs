namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        ZipCodeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EmployeeID)
                .ForeignKey("dbo.ZipCodes", t => t.ZipCodeId, cascadeDelete: true)
                .Index(t => t.ZipCodeId);
            
            CreateTable(
                "dbo.ZipCodes",
                c => new
                    {
                        ZipCodeId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ZipCodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "ZipCodeId", "dbo.ZipCodes");
            DropIndex("dbo.Employees", new[] { "ZipCodeId" });
            DropTable("dbo.ZipCodes");
            DropTable("dbo.Employees");
        }
    }
}
