using AutoMapper;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class PrijavaZaUpisBL : IPrijavaZaUpisBL
    {
        private readonly IMapper _mapper;
        private readonly IPrijavaZaUpisDAL _prijavaZaUpisDAL;
        public PrijavaZaUpisBL(IMapper mapper, IPrijavaZaUpisDAL prijavaZaUpisDAL)
        {
            _mapper = mapper;
            _prijavaZaUpisDAL = prijavaZaUpisDAL;
        }
        public PrijavaZaUpisVM NovaPrijava(PrijavaZaUpisVM prijava)
        {
            try
            {
                var prijavaDB = _mapper.Map<PrijavaZaUpis>(prijava);
                prijavaDB.Procitano = false;
                prijavaDB.Razreseno = false;
                prijavaDB.Odbaceno = false;
                _prijavaZaUpisDAL.Insert(prijavaDB);
                _prijavaZaUpisDAL.SaveChanges();
                var prijavaVM = _mapper.Map<PrijavaZaUpisVM>(prijavaDB);
                return prijavaVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool OdbaciPrijavu(long id)
        {
            try
            {
                var prijavaDB = _prijavaZaUpisDAL.Get(id);
                prijavaDB.Odbaceno = true;
                prijavaDB.Razreseno = true;

                _prijavaZaUpisDAL.Update(prijavaDB);
                _prijavaZaUpisDAL.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool OznaciKaoProcitano(long id)
        {
            try
            {
                var prijavaDB = _prijavaZaUpisDAL.Get(id);
                prijavaDB.Procitano = true;

                _prijavaZaUpisDAL.Update(prijavaDB);
                _prijavaZaUpisDAL.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool RazresiPrijavu(long id)
        {
            try
            {
                var prijavaDB = _prijavaZaUpisDAL.Get(id);
                prijavaDB.Razreseno = true;

                _prijavaZaUpisDAL.Update(prijavaDB);
                _prijavaZaUpisDAL.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<PrijavaZaUpisVM> VratiSvePrijaveZaUpis()
        {
            try
            {
                var prijaveZaUpisDB = _prijavaZaUpisDAL.GetFor(p => p.Razreseno != true).ToList();
                var prijaveVM = _mapper.Map<List<PrijavaZaUpisVM>>(prijaveZaUpisDB);
                return prijaveVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
