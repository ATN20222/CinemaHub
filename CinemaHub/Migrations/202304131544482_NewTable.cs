namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable : DbMigration
    {
        public override void Up()
        {
   
            Sql("DROP TABLE UserMovies");

        }
        
        public override void Down()
        {
        }
    }
}
