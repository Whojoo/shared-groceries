using Microsoft.Extensions.DependencyInjection;

namespace SharedGrocery.Common.Config
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc();
 
            return services;
        }
    }
}