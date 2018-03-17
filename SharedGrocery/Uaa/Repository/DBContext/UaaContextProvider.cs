using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.Uaa.Repository.DBContext
{
    public class UaaContextProvider : IDesignTimeDbContextFactory<UaaContext>
    {
        private readonly IConfiguration _configuration;
        
        public UaaContextProvider()
        {
            var builder = new ConfigurationBuilder()
                // ReSharper disable once PossibleNullReferenceException
                .SetBasePath(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "/SharedGrocery/SharedGrocery/")
                .AddJsonFile("appsettings.json", false, true)
                // Environment variables have to be used outside of development, so hardcode development here. -Robin
                .AddJsonFile("appsettings.Development.json", true, true)
                .AddEnvironmentVariables();

            _configuration = builder.Build();
        }

        public UaaContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<UaaContext>();
            options.UseNpgsql(_configuration.GetConnectionString("Uaa"));
            return new UaaContext(options.Options);
        }
    }
}