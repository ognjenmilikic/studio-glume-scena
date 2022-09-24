using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudioGlumeScena.DataAccess.Migrations
{
    public partial class _300722_009_DML : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sql = @"INSERT INTO dbo.Grupa (VremeOdrzavanjaCasa, DanOdrzavanjaCasa, AktivanZadatak, LokacijaId, ProfesorId, UzrastId) VALUES
                        ('13:00', 'Subota', 'Dramski monolog po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturni centar Rakovica'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE N'Srđan'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Mlađi osnovci')),
                        ('15:00', 'Subota', 'Poezija po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturni centar Rakovica'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE N'Srđan'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Stariji osnovci')),
                        ('18:00', 'Nedelja', 'Pet imitacija', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturni centar Rakovica'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Milena'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Srednjoškolci')),
                        ('12:00', 'Subota', 'Imitacije životinja', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturno-sportski centar Pinki'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Milena'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Mlađi osnovci')),
                        ('14:00', 'Subota', 'Poezija po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturno-sportski centar Pinki'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Zoran'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Stariji osnovci')),
                        ('20:00', 'Ponedeljak', 'Beseda po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Kulturno-sportski centar Pinki'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Zoran'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Srednjoškolci')),
                        ('13:00', 'Subota', N'Dečija pesmica po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Sportski centar Šumice'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Bojana'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Mlađi osnovci')),
                        ('18:00', 'Nedelja', 'Epska pesma po izboru', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Sportski centar Šumice'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Bojana'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Stariji osnovci')),
                        ('21:00', 'Utorak', 'Pet imitacija', (SELECT Id FROM dbo.Lokacija WHERE Naziv LIKE 'Sportski centar Šumice'), (SELECT Id FROM dbo.Profesor WHERE Ime LIKE 'Milica'), (SELECT Id FROM dbo.Uzrast WHERE Naziv LIKE N'Srednjoškolci'))";

            migrationBuilder.Sql(sql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var sql = @"DELETE FROM dbo.Grupa";

            migrationBuilder.Sql(sql);
        }
    }
}
