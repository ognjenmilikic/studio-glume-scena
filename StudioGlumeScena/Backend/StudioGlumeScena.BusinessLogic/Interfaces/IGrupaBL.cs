using StudioGlumeScena.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IGrupaBL
    {
        public List<GrupaVM> VratiSve();
        public bool ObrisiGrupu(long id);
        public GrupaVM SacuvajGrupu(GrupaVM grupaVM);
        public GrupaVM KreirajGrupu(GrupaVM grupaVM);
        public GrupaVM IzmeniGrupu(GrupaVM grupaVM);
        public List<GrupaVM> VratiGrupeZaProfesora(long korisnikId);
    }
}
