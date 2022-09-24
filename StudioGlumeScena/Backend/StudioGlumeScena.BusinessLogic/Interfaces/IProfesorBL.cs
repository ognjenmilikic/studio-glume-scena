using StudioGlumeScena.BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Interfaces
{
    public interface IProfesorBL
    {
        public List<ProfesorVM> VratiSve();
        public bool ObrisiProfesora(long id);
        public ProfesorVM SacuvajProfesora(ProfesorVM profesorVM);
        public ProfesorVM KreirajProfesora(ProfesorVM profesorVM);
        public ProfesorVM IzmeniProfesora(ProfesorVM profesorVM);
    }
}
