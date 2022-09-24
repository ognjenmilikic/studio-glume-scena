using AutoMapper;
using Microsoft.Extensions.Configuration;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.Common.Helpers;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static StudioGlumeScena.Common.Enums;

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class ProfesorBL : IProfesorBL
    {
        IProfesorDAL _profesorDAL;
        IMapper _mapper;
        IKorisnikBL _korisnikBL;
        IKorisnickaUlogaDAL _korisnickaUlogaDAL;
        IConfiguration _configuration;
        IKorisnikDAL _korisnikDAL;
        IGrupaDAL _grupaDAL;

        public ProfesorBL(IProfesorDAL profesorDAL, IMapper mapper, IKorisnikBL korisnikBL, IKorisnickaUlogaDAL korisnickaUlogaDAL, IConfiguration configuration, IKorisnikDAL korisnikDAL, IGrupaDAL grupaDAl)
        {
            _profesorDAL = profesorDAL;
            _mapper = mapper;
            _korisnikBL = korisnikBL;
            _korisnickaUlogaDAL = korisnickaUlogaDAL;
            _configuration = configuration;
            _korisnikDAL = korisnikDAL;
            _grupaDAL = grupaDAl;
        }

        public ProfesorVM SacuvajProfesora(ProfesorVM profesorVM)
        {
            try
            {
                return profesorVM.Id > 0 ? IzmeniProfesora(profesorVM) : KreirajProfesora(profesorVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProfesorVM KreirajProfesora(ProfesorVM profesorVM)
        {
            try
            {
                var profesorDB = _mapper.Map<Profesor>(profesorVM);

                var korisnik = new Korisnik();
                korisnik.Email = profesorDB.Email;
                korisnik.KorisnickaUlogaId = _korisnickaUlogaDAL.GetFor(k => k.Sifra == ((long)SifraKorisnickeUloge.Profesor)).First().Id;
                profesorDB.KorisnikId = _korisnikBL.DodajKorisnika(_mapper.Map<KorisnikVM>(korisnik)).Id;

                _profesorDAL.Insert(profesorDB);
                _profesorDAL.SaveChanges();

                profesorVM = _mapper.Map<ProfesorVM>(profesorDB);
                profesorVM.Korisnik.Password = CryptHelper.DecryptString(profesorVM.Korisnik.Password, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value);

                return profesorVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public ProfesorVM IzmeniProfesora(ProfesorVM profesorVM)
        {
            try
            {
                var profesorDB = _mapper.Map<Profesor>(profesorVM);

                profesorDB.Korisnik.Email = profesorDB.Email;
                _korisnikDAL.Update(profesorDB.Korisnik);
                _korisnikDAL.SaveChanges();

                profesorDB.Korisnik = null;

                _profesorDAL.Update(profesorDB);
                _profesorDAL.SaveChanges();

                return _mapper.Map<ProfesorVM>(profesorDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ObrisiProfesora(long id)
        {
            try
            {
                var profesor = _profesorDAL.Get(id);

                if (profesor == null)
                {
                    throw new Exception("Ne postoji učenik sa datim ID-em");
                }

                if (_grupaDAL.GetFor(g => g.ProfesorId == id)?.Count() > 0)
                {
                    throw new Exception("Ne možete obrisati profesora koji predaje nekoj od grupa. Prvo dodelite toj grupi drugoj profesora pa pokušajte ponovo.");
                }

                _profesorDAL.Delete(profesor);
                _profesorDAL.SaveChanges();

                _korisnikBL.ObrisiKorisnika(profesor.KorisnikId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<ProfesorVM> VratiSve()
        {
            try
            {
                var profesorDB = _profesorDAL.VratiSve();
                var profesorVM = _mapper.Map<List<ProfesorVM>>(profesorDB);
                return profesorVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
