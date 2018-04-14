using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedGrocery.Common.Util;
using SharedGrocery.Uaa.Repository.DBContext;

namespace SharedGrocery.Uaa.Config
{
    public static class DbConfig
    {
        public static void AddUaaDatabases(this IServiceCollection services, Common.Config.Config configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<UaaContext>(opt =>
                    opt.UseNpgsql(configuration.SharedGroceries.Data.Uaa.GetConnectionString()));
        }
    }
}