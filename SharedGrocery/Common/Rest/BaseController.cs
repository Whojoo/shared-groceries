using System.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Util;

namespace SharedGrocery.Common.Rest
{
    public abstract class BaseController : Controller
    {
        private readonly ApiConfig _apiConfig;

        protected BaseController(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }

        /// <summary>
        /// Get the current user context
        /// </summary>
        /// <returns>User context in the jwt</returns>
        /// <exception cref="AuthenticationException">Caused when no user context could be found in the jwt</exception>
        protected UserContext GetUserContext()
        {
            var userContext = Request.GetUserContext(_apiConfig);
            if (userContext == null)
            {
                throw new AuthenticationException("No user found in token");
            }

            return userContext;
        }
    }
}