﻿using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Uaa.Rest.Filters;
using SharedGrocery.Uaa.Service;

namespace SharedGrocery.Uaa.Rest
{
    [Authorize]
    [Route("/oauth")]
    [UnauthorizedExceptionFilter]
    public class OAuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public OAuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("google")]
        public async Task<IActionResult> GoogleVerify()
        {
            string authorization = Request.Headers["Authorization"];
            if (authorization == null || !authorization.StartsWith("Bearer "))
            {
                return Unauthorized();
            }

            var rawToken = authorization.Substring(7);
            var jwt = await _authenticationService.GenerateJwtFromGoogleToken(rawToken);

            if (jwt != null)
            {
                return Ok(new
                {
                    token = jwt
                });
            }

            return BadRequest("Token has been altered");
        }
    }
}