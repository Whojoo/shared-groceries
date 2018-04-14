using Microsoft.AspNetCore.Authentication;

namespace SharedGrocery.Common.Authentication
{
    public class JwtAuthenticationOptions : AuthenticationSchemeOptions
    {
        public Config.Config Configuration { get; set; }
    }
}