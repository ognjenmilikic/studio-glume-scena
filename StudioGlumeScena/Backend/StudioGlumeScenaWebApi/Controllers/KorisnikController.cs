using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikBL _korisnikBL;

        public KorisnikController(IKorisnikBL korisnikBL)
        {
            _korisnikBL = korisnikBL;
        }

        [HttpPost]
        [Route("PromeniLozinku")]
        public ActionResult<bool> PromeniLozinku([FromBody] PromeniLozinkuRequest promeniLozinkuRequest)
        {
            try
            {
                var rezultat = _korisnikBL.PromeniLozinku(promeniLozinkuRequest);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
