using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SharedGrocery.Repositories;
using SharedGrocery.Repositories.DBContexts;

namespace SharedGrocery
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Startup
    {
        private readonly ILoggerFactory _loggerFactory;
        private ILogger<Startup> _logger;

        public Startup(IHostingEnvironment hostingEnvironment, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{hostingEnvironment.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
            _loggerFactory = loggerFactory;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // ReSharper disable once UnusedMember.Global
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            _loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            _loggerFactory.AddDebug(LogLevel.Debug);
            _logger = _loggerFactory.CreateLogger<Startup>();
            
            services.AddMvc();
            services.AddDbContext<GroceryDataContext>(opt =>
                opt.UseSqlServer(Configuration.GetConnectionString("Groceries")));

            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            
            containerBuilder.Populate(services);

            var container = containerBuilder.Build();
            return container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        // ReSharper disable once UnusedMember.Global
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            _logger?.LogDebug("Configuring app");
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}