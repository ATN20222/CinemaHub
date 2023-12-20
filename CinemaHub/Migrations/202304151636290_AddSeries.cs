namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeries : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeriesId = c.Int(nullable: false),
                        VidSrc = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Series", t => t.SeriesId, cascadeDelete: true)
                .Index(t => t.SeriesId);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ReleaseDate = c.String(),
                        ImgSrc = c.String(),
                        Description = c.String(),
                        GenreId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Episodes", "SeriesId", "dbo.Series");
            DropForeignKey("dbo.Series", "GenreId", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "GenreId" });
            DropIndex("dbo.Episodes", new[] { "SeriesId" });
            DropTable("dbo.Series");
            DropTable("dbo.Episodes");
        }
    }
}
