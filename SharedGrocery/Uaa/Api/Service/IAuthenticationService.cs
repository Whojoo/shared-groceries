﻿using System.Threading.Tasks;

namespace SharedGrocery.Uaa.Api.Service
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generates a Jwt token from a google id token, throws exception of the id token is not valid.
        /// </summary>
        /// <param name="idToken">Google id token</param>
        /// <returns>Jwt token for this application</returns>
        Task<string> GenerateJwtFromGoogleToken(string idToken);
    }
}