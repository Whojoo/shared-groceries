using Autofac;
using SharedGrocery.Uaa.Config;

namespace SharedGrocery.Uaa.DI
{
    public class UaaConfigurationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<GoogleClientConfig>().AsSelf();
        }
    }
}