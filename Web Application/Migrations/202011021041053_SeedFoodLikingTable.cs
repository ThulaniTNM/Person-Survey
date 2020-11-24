namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedFoodLikingTable : DbMigration
    {
        public override void Up()
        {
          
            Sql("INSERT INTO Foods(Name) VALUES('Pizza')");
            Sql("INSERT INTO Foods(Name) VALUES('Pasta')");
            Sql("INSERT INTO Foods(Name) VALUES('Pap and Wors')");
            Sql("INSERT INTO Foods(Name) VALUES('Chicken Stir Fry')");
            Sql("INSERT INTO Foods(Name) VALUES('Beef Stir Fry')");
            Sql("INSERT INTO Foods(Name) VALUES('Other')");

        }
        
        public override void Down()
        {
        }
    }
}
