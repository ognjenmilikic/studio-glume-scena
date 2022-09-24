using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Interfaces
{
    public interface IUcenikDAL : IBaseDAL<Ucenik>
    {
        public List<Ucenik> VratiSve();
        public Ucenik VratiUcenikaZaIdKorisnika(long korisnikId);
    }
}
