using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Mef2DiExtensions
{
    class Program
    {
        static async Task Main(string[] args)
        {
            IHostBuilder builder = new HostBuilder()
                .ConfigureServices((hostBuilderContext, services) =>
                {
                    services.AddHostedService<Service>();
                });

            await builder.RunConsoleAsync();
        }
    }
}
