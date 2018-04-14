using System;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using JWT;
using JWT.Builder;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;
using SharedGrocery.Common.Util;

namespace SharedGrocery.Common.Authentication
{
    public class JwtAuthenticationHandler : AuthenticationHandler<JwtAuthenticationOptions>
    {
        private readonly Config.Config _config;
        
        public JwtAuthenticationHandler(IOptionsMonitor<JwtAuthenticationOptions> options, ILoggerFactory logger,
            UrlEncoder encoder, ISystemClock clock)
            : base(options, logger, encoder, clock)
        {
            _config = options.CurrentValue.Configuration;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var token = Request.Headers.GetBearerAuthorization();
            if (string.IsNullOrEmpty(token))
            {
                return Task.FromResult(AuthenticateResult.Fail("No valid token present"));
            }

            try
            {
                var userContext = new JwtBuilder().GetDefaultJwtConfig(_config.SharedGroceries.Api)
                    .MustVerifySignature()
                    .Decode<UserContext>(token);
                Logger.LogInformation($"Verfied user {userContext}");
                var ticket =
                    new AuthenticationTicket(ClaimsPrincipal.Current, new AuthenticationProperties(), "Bearer");
                return Task.FromResult(AuthenticateResult.Success(ticket));
            }
            catch (TokenExpiredException)
            {
                Logger.LogInformation($"Token expired: {token}");
                return Task.FromResult(AuthenticateResult.Fail("Token expired"));
            }
            catch (SignatureVerificationException)
            {
                Logger.LogInformation($"Token invalid signature: {token}");
                return Task.FromResult(AuthenticateResult.Fail("Token has invalid signature"));
            }
            catch (Exception)
            {
                Logger.LogInformation($"Token unknown expection: {token}");
                return Task.FromResult(AuthenticateResult.Fail("Unknown error"));
            }
        }
        
    }
}