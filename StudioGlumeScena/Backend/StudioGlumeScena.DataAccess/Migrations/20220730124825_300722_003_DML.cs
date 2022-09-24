using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_003_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Korisnik ( Email, Password, KorisnickaUlogaId ) VALUES
                        ( 'ognjen.milikic@gmail.com', 'rmv3jzeOvfT4shjtUUj2HQ==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Administrator')),
                        ( 'srdjan.popovic@gmail.com', 'Ml2HqggQyiVf74LwaYdCtw==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Profesor')),
                        ( 'milena.pavlovic@gmail.com', 'd4yB/qHo/IuYIRqNpAUi9w==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Profesor')),
                        ( 'zoran.zivkovic@gmail.com', 'yKheu11Jk3R31g81tW54Dg==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Profesor')),
                        ( 'bojana.petrovic@gmail.com', 'oaNKXHU3EDJ9kvxnzP6TfQ==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Profesor')),
                        ( 'milica.zdravkovic@gmail.com', 'IHVo180tapv8de5wLPc+pw==', (SELECT Id FROM dbo.KorisnickaUloga WHERE Naziv LIKE 'Profesor'))";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Korisnik";

            migrationBuilder.Sql(sql);
        }
    }
}
