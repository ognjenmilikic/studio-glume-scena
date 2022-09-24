using AutoMapper;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class LokacijaBL : ILokacijaBL
    {
        private readonly ILokacijaDAL _lokacijaDAL;
        private readonly IMapper _mapper;

        public LokacijaBL(ILokacijaDAL lokacijaDAL, IMapper mapper)
        {
            _lokacijaDAL = lokacijaDAL;
            _mapper = mapper;
        }

        public List<LokacijaVM> VratiSveLokacije()
        {
            try
            {
                var lokacijeDB = _lokacijaDAL.GetAll();
                var lokacijeVM = _mapper.Map<List<LokacijaVM>>(lokacijeDB);
                return lokacijeVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
