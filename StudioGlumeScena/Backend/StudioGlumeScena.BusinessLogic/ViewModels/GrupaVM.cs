using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.ViewModels
{
    public class GrupaVM
    {
        public long Id { get; set; }
        public string VremeOdrzavanjaCasa { get; set; }
        public string DanOdrzavanjaCasa { get; set; }
        public string AktivanZadatak { get; set; }
        public long LokacijaId { get; set; }
        public LokacijaVM Lokacija { get; set; }
        public long ProfesorId { get; set; }
        public ProfesorVM Profesor { get; set; }
        public long UzrastId { get; set; }
        public UzrastVM Uzrast { get; set; }
        public List<UcenikVM> Ucenik { get; set; }
    }
}
