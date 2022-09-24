using Microsoft.EntityFrameworkCore;

namespace StudioGlumeScena.DataAccess.Models
{
    public class StudioGlumeScenaContext : DbContext
    {
        public StudioGlumeScenaContext(DbContextOptions options) : base(options) { }

        public DbSet<PrijavaZaUpis> PrijavaZaUpis { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<KorisnickaUloga> KorisnickaUloga { get; set; }
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Ucenik> Ucenik { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Lokacija> Lokacija { get; set; }
        public DbSet<Grupa> Grupa { get; set; }
        public DbSet<Uzrast> Uzrast { get; set; }
    }
}
