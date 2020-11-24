namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTablesIdentitySeeds : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('People', RESEED, 100)");
            Sql("DBCC CHECKIDENT ('Foods', RESEED, 1)");
            Sql("DBCC CHECKIDENT ('Likings', RESEED, 200)");
            Sql("DBCC CHECKIDENT ('PersonFoods', RESEED, 300)");
            Sql("DBCC CHECKIDENT ('PersonLikings', RESEED, 400)");
        }
        
        public override void Down()
        {
        }
    }
}
