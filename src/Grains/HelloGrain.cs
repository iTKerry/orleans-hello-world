using System.Threading.Tasks;
using Grains.Abstractions;
using Microsoft.Extensions.Logging;
using Orleans;

namespace Grains
{
    public class HelloGrain : Grain, IHello
    {
        private readonly ILogger _logger;

        public HelloGrain(ILogger<HelloGrain> logger) => _logger = logger;

        public Task<string> SayHello(string greeting)
        {
            _logger.LogInformation($"\n SayHello message received: greeting = '{greeting}'");
            return Task.FromResult($"\n Client said: '{greeting}', so HelloGrain says: Hello!");
        }
    }
}