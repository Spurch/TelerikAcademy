namespace MovieSystem.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Name = c.String(nullable: false),
                        Year = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        LeadingFemale_Id = c.Int(),
                        LeadingMale_Id = c.Int(),
                        Actor_Id = c.Int(),
                        Studio_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.LeadingFemale_Id)
                .ForeignKey("dbo.Actors", t => t.LeadingMale_Id)
                .ForeignKey("dbo.Actors", t => t.Actor_Id)
                .ForeignKey("dbo.Studios", t => t.Studio_Id)
                .Index(t => t.LeadingFemale_Id)
                .Index(t => t.LeadingMale_Id)
                .Index(t => t.Actor_Id)
                .Index(t => t.Studio_Id);
            
            CreateTable(
                "dbo.Studios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Studio_Id", "dbo.Studios");
            DropForeignKey("dbo.Movies", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.Movies", "LeadingMale_Id", "dbo.Actors");
            DropForeignKey("dbo.Movies", "LeadingFemale_Id", "dbo.Actors");
            DropIndex("dbo.Movies", new[] { "Studio_Id" });
            DropIndex("dbo.Movies", new[] { "Actor_Id" });
            DropIndex("dbo.Movies", new[] { "LeadingMale_Id" });
            DropIndex("dbo.Movies", new[] { "LeadingFemale_Id" });
            DropTable("dbo.Studios");
            DropTable("dbo.Movies");
            DropTable("dbo.Actors");
        }
    }
}
