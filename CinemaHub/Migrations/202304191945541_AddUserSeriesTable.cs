namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSeriesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSeries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        SeriesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.SeriesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSeries", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserSeries", "SeriesId", "dbo.Series");
            DropIndex("dbo.UserSeries", new[] { "SeriesId" });
            DropIndex("dbo.UserSeries", new[] { "UserId" });
            DropTable("dbo.UserSeries");
        }
    }
}
