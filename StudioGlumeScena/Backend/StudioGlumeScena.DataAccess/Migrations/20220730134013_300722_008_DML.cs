using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_008_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Uzrast (Sifra, Naziv) VALUES
                        ('1', N'Mlađi osnovci'),
                        ('2', N'Stariji osnovci'),
                        ('3', N'Srednjoškolci')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Uzrast";

            migrationBuilder.Sql(sql);
        }
    }
}
