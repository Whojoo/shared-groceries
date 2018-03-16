using System;
using System.Reactive.Linq;
using System.Reactive.Threading.Tasks;
using System.Threading.Tasks;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace SharedGrocery.Uaa.Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly string _googleClientId;
        private readonly ILogger<AuthenticationService> _logger;

        public AuthenticationService(ILogger<AuthenticationService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _googleClientId = configuration.GetValue<string>("GOOGLE_CLIENT_ID");
            if (_googleClientId == null)
            {
                throw new Exception("No Google client id configured!");
            }
        }

        public async Task<bool> VerifyGoogleIdToken(string idToken)
        {
            return await GoogleJsonWebSignature.ValidateAsync(idToken).ToObservable().Select(IsPayloadValid).ToTask();
        }

        private bool IsPayloadValid(GoogleJsonWebSignature.Payload arg)
        {
            return _googleClientId.Equals(arg.Audience);
        }
    }
}