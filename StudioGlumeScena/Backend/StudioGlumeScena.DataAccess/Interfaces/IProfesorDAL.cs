using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.DataAccess.Interfaces
{
    public interface IProfesorDAL : IBaseDAL<Profesor>
    {
        public List<Profesor> VratiSve();
    }
}
