namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMovies : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('El padrino', 3, '1972/12/15', GETDATE(), 5 )");
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('El padrino. Parte II ', 3, '1974/10/02', GETDATE(), 8 )");
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('La lista de Schindler ', 2, '1993/02/10', GETDATE(), 5 )");
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('Pulp Fiction', 1, '1994/05/20', GETDATE(), 3 )");
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('El pianista', 2, '2002/06/12', GETDATE(), 2 )");
            Sql("INSERT INTO Movies(Name, Genre_Id, ReleaseDate, DateAdded, NumberInStock) VALUES('Avatar', 5, '2009/06/03', GETDATE(), 6 )");
        }
        
        public override void Down()
        {
        }
    }
}
