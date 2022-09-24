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
    public class GrupaDAL : BaseDAL<Grupa>, IGrupaDAL
    {
        public GrupaDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public List<Grupa> VratiGrupeZaProfesora(long korisnikId)
        {
            try
            {
                return _context.Grupa.Include(g => g.Lokacija).Include(g => g.Profesor).Include(g => g.Uzrast).Include(g => g.Ucenik).ThenInclude(u => u.Korisnik).Where(g => g.Profesor.KorisnikId == korisnikId).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Grupa> VratiSve()
        {
            try
            {
                return _context.Grupa.Include(g => g.Lokacija).Include(g => g.Profesor).Include(g => g.Uzrast).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
