using System.Threading.Tasks;
using Google.Apis.Auth;
using Google.Apis.Util;
using Microsoft.Extensions.Options;
using SharedGrocery.Common.Config;
using SharedGrocery.Uaa.Api.Model;
using SharedGrocery.Uaa.Api.Util;
using SharedGrocery.Uaa.Config;

namespace SharedGrocery.Uaa.Util
{
    public class GoogleJwtUtil : IExternalIdUtil
    {
        private readonly UaaGoogleConfig _googleClientConfig;

        public GoogleJwtUtil(IOptions<Common.Config.Config> config)
        {
            _googleClientConfig = config.Value.SharedGroceries.Uaa.Google;
        }

        public async Task<ExternalIdPayload> ValidateExternalId(string idToken)
        {
            var externalPayload = await GoogleJsonWebSignature.ValidateAsync(idToken);
            if (!_googleClientConfig.ClientId.Equals(externalPayload.Audience))
            {
                throw new InvalidJwtException("Jwt not for this application!");
            }

            return new ExternalIdPayload
            {
                Id = externalPayload.Subject
            };
        }
    }
}