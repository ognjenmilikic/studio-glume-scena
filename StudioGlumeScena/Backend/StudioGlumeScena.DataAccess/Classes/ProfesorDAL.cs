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
    public class ProfesorDAL : BaseDAL<Profesor>, IProfesorDAL
    {
        public ProfesorDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
        }

        public List<Profesor> VratiSve()
        {
            try
            {
                return _context.Profesor.Include(u => u.Korisnik).ThenInclude(k => k.KorisnickaUloga).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
