namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCustomerController : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        StreetAddress = c.String(),
                        Balance = c.Int(nullable: false),
                        ZipCodeId = c.Int(nullable: false),
                        PickUpDate = c.String(),
                    })
                .PrimaryKey(t => t.CustomerID)
                .ForeignKey("dbo.ZipCodes", t => t.ZipCodeId, cascadeDelete: true)
                .Index(t => t.ZipCodeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ZipCodeId", "dbo.ZipCodes");
            DropIndex("dbo.Customers", new[] { "ZipCodeId" });
            DropTable("dbo.Customers");
        }
    }
}
