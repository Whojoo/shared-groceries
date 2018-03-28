using Autofac;
using SharedGrocery.Common.Api.Util;
using SharedGrocery.Common.Util;

namespace SharedGrocery.Common.DI
{
    public static class CommonModules
    {
        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CommonConfigurationModule>();
            containerBuilder.RegisterType<Clock>().As<IClock>();
        }
    }
}