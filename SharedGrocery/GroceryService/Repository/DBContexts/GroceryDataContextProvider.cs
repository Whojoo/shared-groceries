﻿using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SharedGrocery.GroceryService.Repository.DBContexts
{
    // ReSharper disable once UnusedMember.Global
    public class GroceryDataContextProvider : IDesignTimeDbContextFactory<GroceryDataContext>
    {
        private readonly IConfiguration _configuration;
        
        public GroceryDataContextProvider()
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

        public GroceryDataContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<GroceryDataContext>();
            options.UseNpgsql(_configuration.GetConnectionString("Groceries"));
            return new GroceryDataContext(options.Options);
        }
    }
}