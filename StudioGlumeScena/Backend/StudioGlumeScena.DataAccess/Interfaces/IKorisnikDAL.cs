using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Interfaces
{
    public interface IKorisnikDAL : IBaseDAL<Korisnik>
    {
        public Korisnik VratiKorisnikaZaEmail(string email);
    }
}
