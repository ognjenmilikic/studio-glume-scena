using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LokacijaController : ControllerBase
    {
        private readonly ILokacijaBL _lokacijaBL;

        public LokacijaController(ILokacijaBL lokacijaBL)
        {
            _lokacijaBL = lokacijaBL;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("VratiSveLokacije")]
        public ActionResult<List<LokacijaVM>> VratiSveLokacije()
        {
            try
            {
                var rezultat = _lokacijaBL.VratiSveLokacije();
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
