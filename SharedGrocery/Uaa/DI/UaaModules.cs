using Autofac;
using SharedGrocery.Uaa.Api.Repository;
using SharedGrocery.Uaa.Api.Service;
using SharedGrocery.Uaa.Api.Util;
using SharedGrocery.Uaa.Repository;
using SharedGrocery.Uaa.Service;
using SharedGrocery.Uaa.Util;

namespace SharedGrocery.Uaa.DI
{
    public static class UaaModules
    {
        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<UaaConfigurationModule>();
            
            containerBuilder.RegisterType<UserService>().As<IUserService>();
            containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<GoogleJwtUtil>().As<IExternalIdUtil>();
        }
    }
}