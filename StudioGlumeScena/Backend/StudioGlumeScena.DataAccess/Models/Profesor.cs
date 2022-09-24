using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public List<Grupa> Grupa { get; set; }
        public long KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
