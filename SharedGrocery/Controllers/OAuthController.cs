using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Dto;
using SharedGrocery.Services;

namespace SharedGrocery.Controllers
{
    [Route("/oauth")]
    public class OAuthController : Controller
    {
        private readonly IUserService _userService;

        public OAuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("google")]
        public IActionResult GoogleSignIn([FromBody] GoogleSignInTokenDto token)
        {
            _userService.ValidateGoogleToken(token.Token);
            return NoContent();
        }
    }
}