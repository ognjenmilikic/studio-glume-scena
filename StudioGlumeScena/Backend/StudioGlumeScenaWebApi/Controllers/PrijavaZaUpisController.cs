using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PrijavaZaUpisController : ControllerBase
    {
        private readonly IPrijavaZaUpisBL _prijavaZaUpisBL;
        public PrijavaZaUpisController(IPrijavaZaUpisBL prijavaZaUpis)
        {
            _prijavaZaUpisBL = prijavaZaUpis;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("NovaPrijava")]
        public ActionResult<PrijavaZaUpisVM> NovaPrijava([FromBody]PrijavaZaUpisVM prijava)
        {
            try
            {
                var rezultat = _prijavaZaUpisBL.NovaPrijava(prijava);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("VratiSvePrijaveZaUpis")]
        public ActionResult<List<PrijavaZaUpisVM>> VratiSvePrijaveZaUpis()
        {
            try
            {
                var rezultat = _prijavaZaUpisBL.VratiSvePrijaveZaUpis();
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("OdbaciPrijavu/{id}")]
        public ActionResult<bool> OdbaciPrijavu(long id)
        {
            try
            {
                var rezultat = _prijavaZaUpisBL.OdbaciPrijavu(id);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("OznaciKaoProcitano/{id}")]
        public ActionResult<bool> OznaciKaoProcitano(long id)
        {
            try
            {
                var rezultat = _prijavaZaUpisBL.OznaciKaoProcitano(id);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        [Route("RazresiPrijavu/{id}")]
        public ActionResult<bool> RazresiPrijavu(long id)
        {
            try
            {
                var rezultat = _prijavaZaUpisBL.RazresiPrijavu(id);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
