using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _1108_002_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"UPDATE dbo.Profesor SET Email = 'srdjan.popovic@gmail.com' WHERE Ime LIKE N'Srđan'
                        UPDATE dbo.Profesor SET Email = 'milena.pavlovic@gmail.com' WHERE Ime LIKE N'Milena'
                        UPDATE dbo.Profesor SET Email = 'zoran.zivkovic@gmail.com' WHERE Ime LIKE N'Zoran'
                        UPDATE dbo.Profesor SET Email = 'bojana.petrovic@gmail.com' WHERE Ime LIKE N'Bojana'
                        UPDATE dbo.Profesor SET Email = 'milica.zdravkovic@gmail.com' WHERE Ime LIKE N'Milica'";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"UPDATE dbo.Profesor SET Email = ''";

            migrationBuilder.Sql(sql);
        }
    }
}
