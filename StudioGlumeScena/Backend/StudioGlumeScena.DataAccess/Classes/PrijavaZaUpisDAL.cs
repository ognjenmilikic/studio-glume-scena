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
    public class PrijavaZaUpisDAL : BaseDAL<PrijavaZaUpis>, IPrijavaZaUpisDAL
    {
        private new readonly StudioGlumeScenaContext _context;
        public PrijavaZaUpisDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
            _context = context;
        }
    }
}
