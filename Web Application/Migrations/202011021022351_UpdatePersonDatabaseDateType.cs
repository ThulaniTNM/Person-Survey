namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatePersonDatabaseDateType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.People", "Date", c => c.DateTime(nullable: false, storeType: "date"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.People", "Date", c => c.DateTime(nullable: false));
        }
    }
}
