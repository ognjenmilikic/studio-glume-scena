using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UzrastController : ControllerBase
    {
        private readonly IUzrastBL _uzrastBL;

        public UzrastController(IUzrastBL uzrastBL)
        {
            _uzrastBL = uzrastBL;
        }

        [Route("VratiSve")]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        public ActionResult<List<UzrastVM>> VratiSve()
        {
            try
            {
                var result = _uzrastBL.VratiSve();

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
