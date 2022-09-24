using Microsoft.IdentityModel.Tokens;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using StudioGlumeScena.Common.Helpers;

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class AuthBL : IAuthBL
    {
        private readonly IKorisnikDAL _korisnikDAL;
        private readonly IConfiguration _configuration;

        public AuthBL(IKorisnikDAL korisnikDAL, IConfiguration configuration)
        {
            _korisnikDAL = korisnikDAL;
            _configuration = configuration;
        }

        public AuthenticatedResponse Login(LoginCredentialsVM loginCredentials)
        {
            try
            {
                var korisnik = _korisnikDAL.VratiKorisnikaZaEmail(loginCredentials.Email);

                if(korisnik == null)
                {
                    throw new Exception("Ne postoji korisnik sa unetim e-mail-om.");
                }
                else if (CryptHelper.DecryptString(korisnik.Password, _configuration.GetSection("AuthSettings").GetSection("AESEncryptionKey").Value) != loginCredentials.Password)
                {
                    throw new Exception("Uneli ste pogrešnu lozinku.");
                }
                else
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AuthSettings").GetSection("JwtSecretKey").Value));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                    var claims = new List<Claim>
                    {
                        new Claim("KorisnikId", korisnik.Id.ToString()),
                        new Claim("Email", korisnik.Email),
                        new Claim("SifraUloge", korisnik.KorisnickaUloga.Sifra.ToString()),
                        new Claim(ClaimTypes.Role, korisnik.KorisnickaUloga.Naziv)
                    };

                    if(korisnik.Administrator.Count > 0)
                    {
                        var administrator = korisnik.Administrator.First();
                        claims.Add(new Claim("Ime", administrator.Ime));
                        claims.Add(new Claim("Prezime", administrator.Prezime));
                    }
                    else if (korisnik.Profesor.Count > 0)
                    {
                        var profesor = korisnik.Profesor.First();
                        claims.Add(new Claim("Ime", profesor.Ime));
                        claims.Add(new Claim("Prezime", profesor.Prezime));
                    }
                    else if (korisnik.Ucenik.Count > 0)
                    {
                        var ucenik = korisnik.Ucenik.First();
                        claims.Add(new Claim("Ime", ucenik.Ime));
                        claims.Add(new Claim("Prezime", ucenik.Prezime));
                    }

                    var tokenOptions = new JwtSecurityToken(
                        issuer: "http://localhost:4200",
                        audience: "http://localhost:4200",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(120),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                    return new AuthenticatedResponse{Token = tokenString};
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
