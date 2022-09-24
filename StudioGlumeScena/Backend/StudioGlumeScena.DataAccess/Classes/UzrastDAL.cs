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
    public class UzrastDAL : BaseDAL<Uzrast>, IUzrastDAL
    {
        public UzrastDAL(StudioGlumeScenaContext context, IConfiguration configuration) : base(context, configuration)
        {
        }
    }
}
