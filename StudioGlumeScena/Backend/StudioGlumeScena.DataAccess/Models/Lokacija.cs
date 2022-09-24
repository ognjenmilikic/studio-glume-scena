using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("Lokacija")]
    public class Lokacija
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string MapaSource { get; set; }
    }
}
