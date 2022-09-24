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
    public class UcenikDAL : BaseDAL<Ucenik>, IUcenikDAL
    {
        public UcenikDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public List<Ucenik> VratiSve()
        {
            try
            {
                return _context.Ucenik.Include(u => u.Grupa).Include(u => u.Korisnik).ThenInclude(k => k.KorisnickaUloga).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Ucenik VratiUcenikaZaIdKorisnika(long korisnikId)
        {
            try
            {
                return _context.Ucenik.Include(u => u.Grupa).ThenInclude(g => g.Lokacija).Include(u => u.Grupa).ThenInclude(g => g.Profesor).Where(u => u.KorisnikId == korisnikId).First();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
