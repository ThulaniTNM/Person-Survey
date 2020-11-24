namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikingValuePersonLiking : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PersonLikings", "LikingValue", c => c.String());
            AddColumn("dbo.Likings", "Likes", c => c.String(nullable: false));
            DropColumn("dbo.Likings", "LikingValue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Likings", "LikingValue", c => c.String(nullable: false));
            DropColumn("dbo.Likings", "Likes");
            DropColumn("dbo.PersonLikings", "LikingValue");
        }
    }
}
