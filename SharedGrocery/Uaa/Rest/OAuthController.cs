﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Uaa.Rest.Filters;
using SharedGrocery.Uaa.Service;

namespace SharedGrocery.Uaa.Rest
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
            string authorization = Request.Headers["Authorization"];
            if (authorization == null || !authorization.StartsWith("Bearer "))
            {
                return Unauthorized();
            }

            var rawToken = authorization.Substring(7);
            var jwtToken = await _authenticationService.GenerateJwtTokenFromGoogleToken(rawToken);

            if (jwtToken != null)
            {
                return Ok(new
                {
                    token = jwtToken
                });
            }

            return BadRequest("Token has been altered");
        }
    }
}