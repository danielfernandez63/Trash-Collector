namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeededZipCodeDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ZipCodes", "ZipCodeArea", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ZipCodes", "ZipCodeArea");
        }
    }
}
