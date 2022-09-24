using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Interfaces
{
    public interface IGrupaDAL : IBaseDAL<Grupa>
    {
        public List<Grupa> VratiSve();
        public List<Grupa> VratiGrupeZaProfesora(long korisnikId);
    }
}
