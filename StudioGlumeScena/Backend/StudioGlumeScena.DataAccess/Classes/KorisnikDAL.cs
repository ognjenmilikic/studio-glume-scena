using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Classes
{
    public class KorisnikDAL : BaseDAL<Korisnik>, IKorisnikDAL
    {
        private new readonly StudioGlumeScenaContext _context;
        public KorisnikDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
            _context = context;
        }

        public Korisnik? VratiKorisnikaZaEmail(string email)
        {
            try
            {
                var korisnik = _context.Korisnik
                    .Include(k => k.KorisnickaUloga)
                    .Include(k => k.Administrator)
                    .Include(k => k.Profesor)
                    .Include(k => k.Ucenik)
                    .Where(k => k.Email.Equals(email));

                return korisnik.Count() == 0 ? null : korisnik.First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
