namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableUserMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movies", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserMovies", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserMovies", "MovieId", "dbo.Movies");
            DropIndex("dbo.UserMovies", new[] { "MovieId" });
            DropIndex("dbo.UserMovies", new[] { "UserId" });
            DropTable("dbo.UserMovies");
        }
    }
}
