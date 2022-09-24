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
    public class UzrastBL : IUzrastBL
    {
        private readonly IUzrastDAL _uzrastDAL;
        private readonly IMapper _mapper;

        public UzrastBL(IUzrastDAL uzrastDAL, IMapper mapper)
        {
            _uzrastDAL = uzrastDAL;
            _mapper = mapper;
        }

        public List<UzrastVM> VratiSve()
        {
            try
            {
                var uzrastDB = _uzrastDAL.GetAll();
                var uzrastVM = _mapper.Map<List<UzrastVM>>(uzrastDB);
                return uzrastVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
