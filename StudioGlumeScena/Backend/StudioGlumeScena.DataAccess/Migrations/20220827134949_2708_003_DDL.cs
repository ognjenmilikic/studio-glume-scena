using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _2708_003_DDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Odbaceno",
                table: "PrijavaZaUpis",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Razreseno",
                table: "PrijavaZaUpis",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Procitano",
                table: "PrijavaZaUpis",
                type: "bit",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Odbaceno",
                table: "PrijavaZaUpis");

            migrationBuilder.DropColumn(
                name: "Procitano",
                table: "PrijavaZaUpis");

            migrationBuilder.DropColumn(
                name: "Razreseno",
                table: "PrijavaZaUpis");
        }
    }
}
