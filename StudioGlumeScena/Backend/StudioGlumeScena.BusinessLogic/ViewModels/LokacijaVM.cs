using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.ViewModels
{
    public class LokacijaVM
    {
        public long Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string KontaktTelefon { get; set; }
        public string MapaSource { get; set; }

    }
}
