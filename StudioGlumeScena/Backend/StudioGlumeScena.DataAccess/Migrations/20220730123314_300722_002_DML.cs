using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_002_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Lokacija(Naziv, Adresa, KontaktTelefon) VALUES
                       ('Kulturni centar Rakovica', N'Miška Kranjca 7', '064 123 2323'),
                       ('Kulturno-sportski centar Pinki', 'Gradski park 2', '065 755 3434'),
                       (N'Sportski centar Šumice', N'Ustanička 125', '066 922 2223')";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Lokacija";

            migrationBuilder.Sql(sql);
        }
    }
}
