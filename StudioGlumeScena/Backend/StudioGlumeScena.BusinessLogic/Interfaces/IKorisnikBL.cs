using StudioGlumeScena.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IKorisnikBL
    {
        public bool PromeniLozinku(PromeniLozinkuRequest promeniLozinkuRequest);
        public KorisnikVM DodajKorisnika(KorisnikVM korisnik);
        public void ObrisiKorisnika(long id);
    }
}
