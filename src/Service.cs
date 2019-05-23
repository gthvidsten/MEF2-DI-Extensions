using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Mef2DiExtensions
{
    public class Service : IHostedService
    {
        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service Starting");
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Service Stopping");
        }
    }
}
