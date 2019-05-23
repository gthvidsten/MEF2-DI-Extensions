using System.Composition.Convention;
using System.Composition.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Mef2DiExtensions.MefExtensions
{
    public class MefServiceProviderBuilder
    {
        ContainerConfiguration _containerConfig;

        public MefServiceProviderBuilder(IServiceCollection services)
        {
            _containerConfig = new ContainerConfiguration()
                .WithAssembly(GetType().Assembly);

            foreach (ServiceDescriptor service in services)
            {
                if (service.ImplementationInstance != null)
                {
                    _containerConfig.WithExport(service.ImplementationInstance, service.ServiceType);
                }
                else if (service.ImplementationFactory != null)
                {
                    _containerConfig.WithFactoryDelegate(() => service.ImplementationFactory(null), service.ServiceType);
                }
                else if (service.ImplementationType != null)
                {
                    _containerConfig.WithPart(service.ImplementationType);
                }
            }
        }

        public CompositionHost Build()
        {
            return _containerConfig.CreateContainer();
        }
    }
}
