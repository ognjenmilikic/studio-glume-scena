using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GrupaController : ControllerBase
    {
        IGrupaBL _grupaBL;

        public GrupaController(IGrupaBL grupaBL)
        {
            _grupaBL = grupaBL;
        }

        [HttpGet]
        [Route("VratiSve")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<List<GrupaVM>> VratiSve()
        {
            try
            {
                var result = _grupaBL.VratiSve();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("ObrisiGrupu/{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<bool> ObrisiGrupu(long id)
        {
            try
            {
                var result = _grupaBL.ObrisiGrupu(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SacuvajGrupu")]
        [Authorize(Roles = "Administrator, Profesor")]
        public ActionResult<GrupaVM> SacuvajGrupu([FromBody] GrupaVM grupaVM)
        {
            try
            {
                var result = _grupaBL.SacuvajGrupu(grupaVM);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("VratiGrupeZaProfesora/{korisnikId}")]
        [Authorize(Roles = "Profesor")]
        public ActionResult<List<GrupaVM>> VratiGrupeZaProfesora(long korisnikId)
        {
            try
            {
                var result = _grupaBL.VratiGrupeZaProfesora(korisnikId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
