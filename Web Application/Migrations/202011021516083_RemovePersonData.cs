namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePersonData : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM People");
        }
        
        public override void Down()
        {
        }
    }
}
