using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("Uzrast")]
    public class Uzrast
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Sifra { get; set; }
        public string Naziv { get; set; }
        public List<Grupa> Grupa { get; set; }
    }
}
