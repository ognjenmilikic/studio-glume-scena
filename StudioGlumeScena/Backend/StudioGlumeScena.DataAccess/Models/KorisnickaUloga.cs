using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("KorisnickaUloga")]
    public class KorisnickaUloga
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long Sifra { get; set; }
        public string Naziv { get; set; }
        public List<Korisnik> Korisnik { get; set; }
    }
}
