using System;
using System.Threading.Tasks;
using Grains.Abstractions;
using Orleans.TestingHost;
using Xunit;

namespace Grains.Tests
{
    [Collection(ClusterCollection.Name)]
    public class HelloGrainTests
    {
        private readonly TestCluster _cluster;

        public HelloGrainTests(ClusterFixture fixture)
        {
            _cluster = fixture.Cluster;
        }

        [Fact]
        public async Task SaysHelloCorrectly()
        {
            const string greetingText = "Hello";
            
            var hello = _cluster.GrainFactory.GetGrain<IHelloGrain>(Guid.NewGuid());
            var greeting = await hello.SayHello(greetingText);

            Assert.Equal($"\n Client said: '{greetingText}', so HelloGrain says: Hello!", greeting);
        }
    }
}