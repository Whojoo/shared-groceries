using Autofac;
using SharedGrocery.Common.Config;
using SharedGrocery.Uaa.Config;

namespace SharedGrocery.Common.DI
{
    public class CommonConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ApiConfig>().AsSelf();
        }
    }
}