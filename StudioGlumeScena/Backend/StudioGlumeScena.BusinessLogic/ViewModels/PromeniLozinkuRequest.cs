using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.ViewModels
{
    public class PromeniLozinkuRequest
    {
        public long KorisnikId { get; set; }
        public string StaraLozinka { get; set; }
        public string NovaLozinka { get; set; }
    }
}
