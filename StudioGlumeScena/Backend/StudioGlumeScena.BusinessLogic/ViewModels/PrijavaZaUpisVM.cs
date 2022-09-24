using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.ViewModels
{
    public class PrijavaZaUpisVM
    {
        public int Id { get; set; }
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
