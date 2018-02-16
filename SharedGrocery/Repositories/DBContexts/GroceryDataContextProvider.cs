using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Repositories.DBContexts
{
    // ReSharper disable once UnusedMember.Global
    public class GroceryDataContextProvider : IDbContextFactory<GroceryDataContext>
    {
        private readonly IConfiguration _configuration;
        
        public GroceryDataContextProvider()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/SharedGrocery/SharedGrocery/")
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile("appsettings.Development.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public GroceryDataContext Create(string[] args)
        {
            var options = new DbContextOptionsBuilder<GroceryDataContext>();
            options.UseSqlServer(_configuration.GetConnectionString("Groceries"));
            return new GroceryDataContext(options.Options);
        }
    }
}