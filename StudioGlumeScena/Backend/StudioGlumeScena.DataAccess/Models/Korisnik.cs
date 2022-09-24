using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public KorisnickaUloga KorisnickaUloga { get; set; }
        public long KorisnickaUlogaId { get; set; }
        public List<Ucenik> Ucenik { get; set; }
        public List<Profesor> Profesor { get; set; }
        public List<Administrator> Administrator { get; set; }
    }
}
