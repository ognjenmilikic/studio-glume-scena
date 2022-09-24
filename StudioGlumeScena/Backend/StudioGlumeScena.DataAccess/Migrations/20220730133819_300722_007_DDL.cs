using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_007_DDL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "UzrastId",
                table: "Grupa",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Uzrast",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sifra = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzrast", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Grupa_UzrastId",
                table: "Grupa",
                column: "UzrastId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grupa_Uzrast_UzrastId",
                table: "Grupa",
                column: "UzrastId",
                principalTable: "Uzrast",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grupa_Uzrast_UzrastId",
                table: "Grupa");

            migrationBuilder.DropTable(
                name: "Uzrast");

            migrationBuilder.DropIndex(
                name: "IX_Grupa_UzrastId",
                table: "Grupa");

            migrationBuilder.DropColumn(
                name: "UzrastId",
                table: "Grupa");
        }
    }
}
