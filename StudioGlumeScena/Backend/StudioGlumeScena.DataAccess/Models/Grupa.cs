using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Models
{
    [Table("Grupa")]
    public class Grupa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string VremeOdrzavanjaCasa { get; set; }
        public string DanOdrzavanjaCasa { get; set; }
        public string AktivanZadatak { get; set; }
        public long LokacijaId { get; set; }
        public Lokacija Lokacija { get; set; }
        public long ProfesorId { get; set; }
        public Profesor Profesor { get; set; }
        public List<Ucenik> Ucenik { get; set; }
        public long UzrastId { get; set; }
        public Uzrast Uzrast { get; set; }
    }
}
