using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("PrijavaZaUpis")]
    public class PrijavaZaUpis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Adresa { get; set; }
        public string BrojTelefona { get; set; }
        public string GodinaRodjenja { get; set; }
        public string Email { get; set; }
        public bool? Procitano { get; set; }
        public bool? Razreseno { get; set; }
        public bool? Odbaceno { get; set; }
    }
}
