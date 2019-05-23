using System.Threading.Tasks;
using Mef2DiExtensions.MefExtensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mef2DiExtensions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder builder = new HostBuilder()
                .UseServiceProviderFactory(new MefServiceProviderFactory())
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddHostedService<Service>();
                });

            await builder.RunConsoleAsync();
        }
    }
}
