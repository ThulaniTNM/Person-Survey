namespace Web_Application.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesConstruction : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foods",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.FoodID);
            
            CreateTable(
                "dbo.PersonFoods",
                c => new
                    {
                        PersonFoodID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        FoodID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonFoodID)
                .ForeignKey("dbo.Foods", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.FoodID);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonID = c.Int(nullable: false, identity: true),
                        Surname = c.String(nullable: false),
                        FirstNames = c.String(nullable: false),
                        Contact = c.String(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonID);
            
            CreateTable(
                "dbo.PersonLikings",
                c => new
                    {
                        PersonFoodID = c.Int(nullable: false, identity: true),
                        PersonID = c.Int(nullable: false),
                        LikingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PersonFoodID)
                .ForeignKey("dbo.Likings", t => t.LikingID, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonID, cascadeDelete: true)
                .Index(t => t.PersonID)
                .Index(t => t.LikingID);
            
            CreateTable(
                "dbo.Likings",
                c => new
                    {
                        LikingID = c.Int(nullable: false, identity: true),
                        LikingValue = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.LikingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PersonLikings", "PersonID", "dbo.People");
            DropForeignKey("dbo.PersonLikings", "LikingID", "dbo.Likings");
            DropForeignKey("dbo.PersonFoods", "PersonID", "dbo.People");
            DropForeignKey("dbo.PersonFoods", "FoodID", "dbo.Foods");
            DropIndex("dbo.PersonLikings", new[] { "LikingID" });
            DropIndex("dbo.PersonLikings", new[] { "PersonID" });
            DropIndex("dbo.PersonFoods", new[] { "FoodID" });
            DropIndex("dbo.PersonFoods", new[] { "PersonID" });
            DropTable("dbo.Likings");
            DropTable("dbo.PersonLikings");
            DropTable("dbo.People");
            DropTable("dbo.PersonFoods");
            DropTable("dbo.Foods");
        }
    }
}
