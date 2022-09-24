using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IPrijavaZaUpisBL
    {
        public PrijavaZaUpisVM NovaPrijava(PrijavaZaUpisVM prijava);
        public List<PrijavaZaUpisVM> VratiSvePrijaveZaUpis();
        public bool OdbaciPrijavu(long id);
        public bool OznaciKaoProcitano(long id);
        public bool RazresiPrijavu(long id);
    }
}
