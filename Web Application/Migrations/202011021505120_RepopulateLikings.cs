namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RepopulateLikings : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM Likings");
            Sql("INSERT INTO Likings(Likes) VALUES('I like to eat out')");
            Sql("INSERT INTO Likings(Likes) VALUES('I like to watch movies')");
            Sql("INSERT INTO Likings(Likes) VALUES('I like to watch TV')");
            Sql("INSERT INTO Likings(Likes) VALUES('I like to listen to the radio')");
        }
        
        public override void Down()
        {
           
        }
    }
}
