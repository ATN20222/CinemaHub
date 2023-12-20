namespace CinemaHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTable2 : DbMigration
    {
        public override void Up()
        {
            Sql("DROP TABLE Users");
        }
        
        public override void Down()
        {
        }
    }
}
