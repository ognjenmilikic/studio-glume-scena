using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _190622_002_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.KorisnickaUloga(Sifra, Naziv) VALUES
                        (1, 'Administrator'), (2, 'Profesor'), (3, N'Učenik')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.KorisnickaUloga WHERE Sifra IN (1,2,3)";

            migrationBuilder.Sql(sql);
        }
    }
}
