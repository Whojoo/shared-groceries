using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Controllers.Filters;
using SharedGrocery.Services;

namespace SharedGrocery.Controllers
{
    [Route("/oauth")]
    [UnauthorizedExceptionFilter]
    public class OAuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public OAuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("google")]
        public async Task<IActionResult> GoogleVerify()
        {
            string token = Request.Headers["Authorization"];
            if (token == null || !token.StartsWith("Bearer "))
            {
                return Unauthorized();
            }

            var rawToken = token.Substring(7);
            var success = await _authenticationService.VerifyGoogleIdToken(rawToken);

            if (success)
            {
                return Ok();
            }

            return BadRequest("Token has been altered");
        }
    }
}