using System;
using Orleans.Hosting;
using Orleans.TestingHost;

namespace Grains.Tests
{
    public class ClusterFixture : IDisposable
    {
        public ClusterFixture()
        {
            var builder = new TestClusterBuilder();
            builder.AddSiloBuilderConfigurator<TestSiloConfigurations>();
            
            Cluster = builder.Build();
            Cluster.Deploy();
        }

        public void Dispose() => Cluster.StopAllSilos();

        public TestCluster Cluster { get; }
    }

    public class TestSiloConfigurations : ISiloBuilderConfigurator {
        public void Configure(ISiloHostBuilder hostBuilder) {
            hostBuilder.ConfigureServices(_ => { });
        }
    }
}