using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudioGlumeScena.BusinessLogic.Interfaces;
using StudioGlumeScena.BusinessLogic.ViewModels;

namespace StudioGlumeScenaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthBL _authBL;
        public AuthController(IAuthBL authBL)
        {
            _authBL = authBL;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public ActionResult<AuthenticatedResponse> Login([FromBody] LoginCredentialsVM loginCredentials)
        {
            try
            {
                var rezultat = _authBL.Login(loginCredentials);
                return Ok(rezultat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
