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

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class KorisnikBL : IKorisnikBL
    {
        private readonly IKorisnikDAL _korisnikDAL;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public KorisnikBL(IKorisnikDAL korisnikDAL, IConfiguration configuration, IMapper mapper)
        {
            _korisnikDAL = korisnikDAL;
            _configuration = configuration;
            _mapper = mapper;
        }

        public KorisnikVM DodajKorisnika(KorisnikVM korisnik)
        {
            try
            {
                var password = RandomString(8);
                var cryptedPassword = CryptHelper.EncryptString(password, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value);
                korisnik.Password = cryptedPassword;

                var korisnikDB = _mapper.Map<Korisnik>(korisnik);
                _korisnikDAL.Insert(korisnikDB);
                _korisnikDAL.SaveChanges();

                var korisnikVM = _mapper.Map<KorisnikVM>(korisnik);
                korisnikVM.Id = _korisnikDAL.GetFor(k => k.Email == korisnik.Email).First().Id;
                return korisnikVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string RandomString(int length)
        {
            Random random = new Random();
            var rString = "";
            for (var i = 0; i < length; i++)
            {
                rString += ((char)(random.Next(1, 26) + 64)).ToString();
            }

            return rString;
        }

        public bool PromeniLozinku(PromeniLozinkuRequest promeniLozinkuRequest)
        {
            try
            {
                var korisnik = _korisnikDAL.Get(promeniLozinkuRequest.KorisnikId);

                if (CryptHelper.DecryptString(korisnik.Password, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value) != promeniLozinkuRequest.StaraLozinka)
                {
                    throw new Exception("Niste uneli ispravnu staru lozinku.");
                }

                korisnik.Password = CryptHelper.EncryptString(promeniLozinkuRequest.NovaLozinka, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value);

                _korisnikDAL.Update(korisnik);

                _korisnikDAL.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void ObrisiKorisnika(long id)
        {
            try
            {
                var korisnikDB = _korisnikDAL.Get(id);
                _korisnikDAL.Delete(korisnikDB);
                _korisnikDAL.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
