using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Http;
using SharedGrocery.Common.Config;
using SharedGrocery.Common.Model;

namespace SharedGrocery.Common.Util
{
    public static class AuthorizationUtil
    {
        private const string AuthorizationHeader = "Authorization";
        private const string BearerPrefix = "Bearer ";

        public static string GetBearerAuthorization(this IHeaderDictionary headerDictionary)
        {
            string authHeader = headerDictionary[AuthorizationHeader];
            if (string.IsNullOrEmpty(authHeader) || !authHeader.StartsWith(BearerPrefix))
            {
                return null;
            }

            return authHeader.Substring(BearerPrefix.Length);
        }

        public static JwtBuilder GetDefaultJwtConfig(this JwtBuilder builder, ApiConfig apiConfig)
        {
            return builder.WithAlgorithm(new HMACSHA256Algorithm())
                .WithSecret(apiConfig.ApiSecret)
                .Issuer("mainrobik.nl");
        }

        public static UserContext GetUserContext(this HttpRequest request, ApiConfig apiConfig)
        {
            var jwt = request.Headers.GetBearerAuthorization();
            return new JwtBuilder().GetDefaultJwtConfig(apiConfig)
                .Decode<UserContext>(jwt);
        }
    }
}