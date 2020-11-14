﻿using System;
using System.Threading.Tasks;
using Grains.Abstractions;
using Microsoft.Extensions.Logging;
using Orleans;
using Orleans.Configuration;

namespace Client
{
    internal static class Program
    {
        private static async Task<int> Main() => await RunMainAsync();

        private static async Task<int> RunMainAsync()
        {
            try
            {
                await using var client = await ConnectClient();
                await DoClientWork(client);
                Console.ReadKey();

                return 0;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nException while trying to run client: {e.Message}");
                Console.WriteLine("Make sure the silo the client is trying to connect to is running.");
                Console.WriteLine("\nPress any key to exit.");
                Console.ReadKey();
                return 1;
            }
        }

        private static async Task<IClusterClient> ConnectClient()
        {
            var client = new ClientBuilder()
                .UseLocalhostClustering()
                .Configure<ClusterOptions>(options =>
                {
                    options.ClusterId = "dev";
                    options.ServiceId = "OrleansBasics";
                })
                .ConfigureLogging(logging => logging.AddConsole())
                .Build();

            await client.Connect();
            Console.WriteLine("Client successfully connected to silo host \n");
            return client;
        }

        private static async Task DoClientWork(IClusterClient client)
        {
            var friend = client.GetGrain<IHelloGrain>(Guid.NewGuid());
            var response = await friend.SayHello("Good morning, HelloGrain!");
            Console.WriteLine($"\n\n{response}\n\n");
        }
    }
}