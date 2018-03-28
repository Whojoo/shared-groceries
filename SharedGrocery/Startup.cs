﻿using System;
 using System.Collections.Generic;
 using Autofac;
 using Autofac.Extensions.DependencyInjection;
 using Microsoft.AspNetCore.Builder;
 using Microsoft.EntityFrameworkCore;
 using Microsoft.Extensions.Configuration;
 using Microsoft.Extensions.DependencyInjection;
 using Microsoft.Extensions.Logging;
 using SharedGrocery.Common.Api.Config;
 using SharedGrocery.Common.Config;
 using SharedGrocery.Common.DI;
 using SharedGrocery.GroceryService.Config;
 using SharedGrocery.GroceryService.DI;
 using SharedGrocery.GroceryService.Repository.DBContexts;
 using SharedGrocery.Uaa.Config;
 using SharedGrocery.Uaa.DI;
 using SharedGrocery.Uaa.Repository.DBContext;

namespace SharedGrocery
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Startup
    {
        private ILogger<Startup> _logger;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // ReSharper disable once UnusedMember.Global
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddJwtAuthentication(Configuration);
            services.AddUaaDatabases(Configuration);
            services.AddGroceryDatabases(Configuration);
            
            var containerBuilder = new ContainerBuilder();
            
            containerBuilder.Populate(services);
            
            var loggingFactory = new LoggerFactory();
            loggingFactory.AddConsole(Configuration.GetSection("Logging"));
            loggingFactory.AddDebug();
            containerBuilder.RegisterInstance(loggingFactory).As<ILoggerFactory>();
            
            CommonModules.RegisterModules(containerBuilder);
            UaaModules.RegisterModules(containerBuilder);
            GroceryModules.RegisterModules(containerBuilder);

            var container = containerBuilder.Build();

            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, GroceryDataContext groceryDataContext, UaaContext uaaContext,
            ILoggerFactory loggerFactory, IEnumerable<IAppConfiguration> appConfigurations)
        {
            foreach (var configuration in appConfigurations)
            {
                configuration.Configure();
            }
            
            _logger = loggerFactory.CreateLogger<Startup>();
            
            _logger?.LogDebug("Starting database migration");
            groceryDataContext.Database.Migrate();
            uaaContext.Database.Migrate();

            app.UseAuthentication();

            app.UseMvc();
        }
    }
}