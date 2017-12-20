namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Genres(Name) VALUES('Comedia')");
            Sql("INSERT INTO Genres(Name) VALUES('Drama')");
            Sql("INSERT INTO Genres(Name) VALUES('Thriller')");
            Sql("INSERT INTO Genres(Name) VALUES('Terror')");
            Sql("INSERT INTO Genres(Name) VALUES('Animación')");
            Sql("INSERT INTO Genres(Name) VALUES('Aventuras')");
        }
        
        public override void Down()
        {
        }
    }
}
