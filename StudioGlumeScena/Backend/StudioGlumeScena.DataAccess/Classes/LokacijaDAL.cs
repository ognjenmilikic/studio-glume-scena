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
    public class LokacijaDAL : BaseDAL<Lokacija>, ILokacijaDAL
    {
        public LokacijaDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
