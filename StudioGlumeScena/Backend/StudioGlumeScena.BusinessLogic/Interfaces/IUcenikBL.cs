using StudioGlumeScena.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IUcenikBL
    {
        public List<UcenikVM> VratiSve();
        public bool ObrisiUcenika(long id);
        public UcenikVM SacuvajUcenika(UcenikVM ucenikVM);
        public UcenikVM KreirajUcenika(UcenikVM ucenikVM);
        public UcenikVM IzmeniUcenika(UcenikVM ucenikVM);
        public UcenikVM VratiUcenikaZaIdKorisnika(long korisnikId);
    }
}
