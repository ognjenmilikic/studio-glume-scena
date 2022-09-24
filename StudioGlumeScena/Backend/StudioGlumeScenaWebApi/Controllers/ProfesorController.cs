using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        IProfesorBL _profesorBL;

        public ProfesorController(IProfesorBL profesorBL)
        {
            _profesorBL = profesorBL;
        }

        [HttpGet]
        [Route("VratiSve")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<List<ProfesorVM>> VratiSve()
        {
            try
            {
                var result = _profesorBL.VratiSve();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        [Route("ObrisiProfesora/{id}")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<bool> ObrisiProfesora(long id)
        {
            try
            {
                var result = _profesorBL.ObrisiProfesora(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("SacuvajProfesora")]
        [Authorize(Roles = "Administrator")]
        public ActionResult<ProfesorVM> SacuvajProfesora([FromBody] ProfesorVM profesorVM)
        {
            try
            {
                var result = _profesorBL.SacuvajProfesora(profesorVM);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
