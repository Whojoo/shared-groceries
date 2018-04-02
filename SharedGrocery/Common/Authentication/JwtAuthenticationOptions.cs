using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Common.Authentication
{
    public class JwtAuthenticationOptions : AuthenticationSchemeOptions
    {
        public IConfiguration Configuration { get; set; }
    }
}