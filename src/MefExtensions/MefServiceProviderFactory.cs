using System;
using System.Composition.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Mef2DiExtensions.MefExtensions
{
    public class MefServiceProviderFactory : IServiceProviderFactory<MefServiceProviderBuilder>
    {
        public MefServiceProviderBuilder CreateBuilder(IServiceCollection services)
        {
            MefServiceProviderBuilder builder = new MefServiceProviderBuilder(services);

            return builder;
        }

        public IServiceProvider CreateServiceProvider(MefServiceProviderBuilder containerBuilder)
        {
            if (containerBuilder == null) throw new ArgumentNullException(nameof(containerBuilder));

            CompositionHost container = containerBuilder.Build();

            return new MefServiceProvider(container);
        }
    }
}
