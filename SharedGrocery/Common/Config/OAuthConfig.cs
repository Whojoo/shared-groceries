using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedGrocery.Common.Authentication;

namespace SharedGrocery.Common.Config
{
    public static class OAuthConfig
    {
        public static void AddJwtAuthentication(this IServiceCollection services, Config configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwt(options => { options.Configuration = configuration; });
        }
        
        private static void AddJwt(this AuthenticationBuilder builder, Action<JwtAuthenticationOptions> configuration)
        {
            builder.AddScheme<JwtAuthenticationOptions, JwtAuthenticationHandler>("Bearer", configuration);
        }
    }
}