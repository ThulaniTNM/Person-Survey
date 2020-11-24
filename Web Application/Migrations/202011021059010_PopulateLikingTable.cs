namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateLikingTable : DbMigration
    {
        public override void Up()
        {
    
        Sql("INSERT INTO Likings(Likes) VALUES('Eat out')");
        Sql("INSERT INTO Likings(Likes) VALUES('Watch movies')");
        Sql("INSERT INTO Likings(Likes) VALUES('Watch TV')");
        Sql("INSERT INTO Likings(Likes) VALUES('Listen to the radio')");
        }
        
        public override void Down()
        {
        }
    }
}
