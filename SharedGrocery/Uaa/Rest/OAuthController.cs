﻿using System.Threading.Tasks;
 using Microsoft.AspNetCore.Authorization;
 using Microsoft.AspNetCore.Mvc;
 using SharedGrocery.Common.Util;
 using SharedGrocery.Uaa.Api.Service;
 using SharedGrocery.Uaa.Rest.Filters;
using SharedGrocery.Uaa.Service;

namespace SharedGrocery.Uaa.Rest
{
    [AllowAnonymous]
    [Route("/oauth")]
    [UnauthorizedExceptionFilter]
    public class OAuthController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public OAuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        /// <summary>
        /// Login using google token.
        /// </summary>
        /// <returns>Jwt for application use</returns>
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin()
        {
            var rawToken = Request.Headers.GetBearerAuthorization();
            if (string.IsNullOrEmpty(rawToken))
            {
                return Unauthorized();
            }
            
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