using AutoMapper;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;
using StudioGlumeScena.DataAccess.Interfaces;
using StudioGlumeScena.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioGlumeScena.BusinessLogic.Classes
{
    public class GrupaBL : IGrupaBL
    {
        private readonly IGrupaDAL _grupaDAL;
        private readonly IMapper _mapper;

        public GrupaBL(IGrupaDAL grupaDAL, IMapper mapper)
        {
            _grupaDAL = grupaDAL;
            _mapper = mapper;
        }

        public GrupaVM SacuvajGrupu(GrupaVM grupaVM)
        {
            try
            {
                return grupaVM.Id > 0 ? IzmeniGrupu(grupaVM) : KreirajGrupu(grupaVM);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GrupaVM KreirajGrupu(GrupaVM grupaVM)
        {
            try
            {
                var grupaDB = _mapper.Map<Grupa>(grupaVM);

                _grupaDAL.Insert(grupaDB);
                _grupaDAL.SaveChanges();

                grupaVM = _mapper.Map<GrupaVM>(grupaDB);

                return grupaVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public GrupaVM IzmeniGrupu(GrupaVM grupaVM)
        {
            try
            {
                var grupaDB = _mapper.Map<Grupa>(grupaVM);

                _grupaDAL.Update(grupaDB);
                _grupaDAL.SaveChanges();

                var grupa = _mapper.Map<GrupaVM>(grupaDB);

                grupa.Ucenik?.ForEach(u =>
                {
                    u.Grupa = null;
                });

                return grupa;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ObrisiGrupu(long id)
        {
            try
            {
                var grupaDB = _grupaDAL.Get(id);

                if (grupaDB == null)
                {
                    throw new Exception("Ne postoji učenik sa datim ID-em");
                }

                _grupaDAL.Delete(grupaDB);
                _grupaDAL.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GrupaVM> VratiSve()
        {
            try
            {
                var grupaDB = _grupaDAL.VratiSve();
                var grupaVM = _mapper.Map<List<GrupaVM>>(grupaDB);
                return grupaVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<GrupaVM> VratiGrupeZaProfesora(long korisnikId)
        {
            try
            {
                var grupaDB = _grupaDAL.VratiGrupeZaProfesora(korisnikId);
                var grupaVM = _mapper.Map<List<GrupaVM>>(grupaDB);

                grupaVM.ForEach(g =>
                {
                    g.Ucenik.ForEach(u =>
                    {
                        u.Grupa = null;
                    });
                });

                return grupaVM;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
