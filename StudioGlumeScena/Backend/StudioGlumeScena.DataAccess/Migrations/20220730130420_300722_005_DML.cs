using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_005_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Profesor (Ime, Prezime, BrojTelefona, Adresa, KorisnikId) VALUES
                        (N'Srđan', N'Popović', '064 234 9887', 'Borska 31', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'srdjan.popovic@gmail.com')),
                        (N'Milena', N'Pavlović', '061 9285 777', 'Šumadijske divizije 18', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'milena.pavlovic@gmail.com')),
                        (N'Zoran', N'Živković', '062 9288 344', 'Timočke divizije 18', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'zoran.zivkovic@gmail.com')),
                        (N'Bojana', N'Petrović', '063 4422 900', 'Vojvode Stepe 244', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'bojana.petrovic@gmail.com')),
                        (N'Milica', N'Zdravković', '061 9285 777', 'Šumadijske divizije 18', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'milica.zdravkovic@gmail.com'))";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Profesor";

            migrationBuilder.Sql(sql);
        }
    }
}
