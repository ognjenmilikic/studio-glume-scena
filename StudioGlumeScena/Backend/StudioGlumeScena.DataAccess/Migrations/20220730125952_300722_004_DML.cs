using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_004_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Administrator (Ime, Prezime, BrojTelefona, KorisnikId) VALUES
                        ('Ognjen', N'Milikić', '064 120 3396', (SELECT Id FROM dbo.Korisnik WHERE Email LIKE 'ognjen.milikic@gmail.com'))";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Administrator WHERE Ime LIKE 'Ognjen'";

            migrationBuilder.Sql(sql);
        }
    }
}
