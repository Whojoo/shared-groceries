using Autofac;

namespace SharedGrocery.Common.DI
{
    public static class CommonModules
    {
        public static void RegisterModules(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterModule<CommonConfigurationModule>();
        }
    }
}