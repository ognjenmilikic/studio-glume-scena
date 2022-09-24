using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UcenikController : ControllerBase
    {
        IUcenikBL _ucenikBL;

        public UcenikController(IUcenikBL ucenikBL)
        {
            _ucenikBL = ucenikBL;
        }

        [HttpGet]
        [Route("VratiSve")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<List<UcenikVM>> VratiSve()
        {
            try
            {
                var result = _ucenikBL.VratiSve();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("ObrisiUcenika/{id}")]
        [Authorize(Roles = "Administrator, Profesor")]
        public ActionResult<bool> ObrisiUcenika(long id)
        {
            try
            {
                var result = _ucenikBL.ObrisiUcenika(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SacuvajUcenika")]
        [Authorize(Roles = "Administrator, Profesor")]
        public ActionResult<UcenikVM> SacuvajUcenika([FromBody] UcenikVM ucenikVM)
        {
            try
            {
                var result = _ucenikBL.SacuvajUcenika(ucenikVM);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Route("VratiUcenikaZaIdKorisnika/{korisnikId}")]
        [Authorize(Roles = "Učenik")]
        public ActionResult<UcenikVM> VratiUcenikaZaIdKorisnika(long korisnikId)
        {
            try
            {
                var result = _ucenikBL.VratiUcenikaZaIdKorisnika(korisnikId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
