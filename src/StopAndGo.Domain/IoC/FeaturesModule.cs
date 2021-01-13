using Autofac;
using Nymbus.Domain.Features.Interfaces;

namespace Nymbus.Domain.IoC
{
    public class FeaturesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<IFeatureService>()
                   .AsImplementedInterfaces()
                   .AsSelf();
        }
    }
}
