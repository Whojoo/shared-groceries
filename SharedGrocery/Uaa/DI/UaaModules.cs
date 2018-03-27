using Autofac;
using SharedGrocery.Uaa.Repository;
using SharedGrocery.Uaa.Service;

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
        }
    }
}