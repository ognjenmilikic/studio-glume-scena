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
    public class UcenikBL : IUcenikBL
    {
        IUcenikDAL _ucenikDAL;
        IMapper _mapper;
        IKorisnikDAL _korisnikDAL;
        IKorisnickaUlogaDAL _korisnickaUlogaDAL;
        IKorisnikBL _korisnikBL;
        IConfiguration _configuration;
        public UcenikBL(IUcenikDAL ucenikDAL, IMapper mapper, IKorisnikDAL korisnikDAL, IKorisnickaUlogaDAL korisnickaUlogaDAL, IKorisnikBL korisnikBL, IConfiguration configuration)
        {
            _ucenikDAL = ucenikDAL;
            _mapper = mapper;
            _korisnikDAL = korisnikDAL;
            _korisnickaUlogaDAL = korisnickaUlogaDAL;
            _korisnikBL = korisnikBL;
            _configuration = configuration;
        }

        public UcenikVM SacuvajUcenika(UcenikVM ucenikVM)
        {
            try
            {
                return ucenikVM.Id > 0 ? IzmeniUcenika(ucenikVM) : KreirajUcenika(ucenikVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UcenikVM KreirajUcenika(UcenikVM ucenikVM)
        {
            try
            {
                var ucenikDB = _mapper.Map<Ucenik>(ucenikVM);

                var korisnik = new Korisnik();
                korisnik.Email = ucenikDB.Email;
                korisnik.KorisnickaUlogaId = _korisnickaUlogaDAL.GetFor(k => k.Sifra == ((long)SifraKorisnickeUloge.Ucenik)).First().Id;
                ucenikDB.KorisnikId = _korisnikBL.DodajKorisnika(_mapper.Map<KorisnikVM>(korisnik)).Id;
                _ucenikDAL.Insert(ucenikDB);
                _ucenikDAL.SaveChanges();

                ucenikVM = _mapper.Map<UcenikVM>(ucenikDB);
                ucenikVM.Korisnik.Password = CryptHelper.DecryptString(ucenikVM.Korisnik.Password, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value);

                return ucenikVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UcenikVM IzmeniUcenika(UcenikVM ucenikVM)
        {
            try
            {
                var ucenikDB = _mapper.Map<Ucenik>(ucenikVM);

                ucenikDB.Korisnik.Email = ucenikDB.Email;
                _korisnikDAL.Update(ucenikDB.Korisnik);
                _korisnikDAL.SaveChanges();

                ucenikDB.Korisnik = null;
                ucenikDB.Grupa = null;

                _ucenikDAL.Update(ucenikDB);
                _ucenikDAL.SaveChanges();

                return _mapper.Map<UcenikVM>(ucenikDB);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ObrisiUcenika(long id)
        {
            try
            {
                var ucenik = _ucenikDAL.Get(id);

                if(ucenik == null)
                {
                    throw new Exception("Ne postoji učenik sa datim ID-em");
                }

                _ucenikDAL.Delete(ucenik);
                _ucenikDAL.SaveChanges();

                _korisnikBL.ObrisiKorisnika(ucenik.KorisnikId);

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<UcenikVM> VratiSve()
        {
            try
            {
                var ucenikDB = _ucenikDAL.VratiSve();
                var ucenikVM = _mapper.Map<List<UcenikVM>>(ucenikDB);

                ucenikVM?.ForEach(u =>
                {
                    u.Grupa.Ucenik = null;
                });

                return ucenikVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public UcenikVM VratiUcenikaZaIdKorisnika(long korisnikId)
        {
            try
            {
                var ucenikDB = _ucenikDAL.VratiUcenikaZaIdKorisnika(korisnikId);
                var ucenikVM = _mapper.Map<UcenikVM>(ucenikDB);

                ucenikVM.Grupa.Ucenik = null;

                return ucenikVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
