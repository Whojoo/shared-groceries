using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedGrocery.Common.Util;
using SharedGrocery.GroceryService.Repository.DBContexts;

namespace SharedGrocery.GroceryService.Config
{
    public static class DbConfig
    {
        
        public static void AddGroceryDatabases(this IServiceCollection services, Common.Config.Config configuration)
        {
            services.AddEntityFrameworkNpgsql()
                .AddDbContext<GroceryDataContext>(opt =>
                    opt.UseNpgsql(configuration.SharedGroceries.Data.Groceries.GetConnectionString()));
        }
    }
}