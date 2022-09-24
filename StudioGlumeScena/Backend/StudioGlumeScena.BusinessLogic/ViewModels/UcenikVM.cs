using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.ViewModels
{
    public class UcenikVM
    {
        public long Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string GodinaRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }
        public long GrupaId { get; set; }
        public GrupaVM Grupa { get; set; }
        public long KorisnikId { get; set; }
        public KorisnikVM Korisnik { get; set; }
    }
}
