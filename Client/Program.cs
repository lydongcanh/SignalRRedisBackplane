using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var url = args[0];
            var connection = new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();

            connection.On("OnTickReceived", (int tick) =>
            {
                Console.WriteLine($"tick: {tick}");
            });

            connection.On("OnConnected", () =>
            {
                Console.WriteLine("Connected...");
            });

            await connection.StartAsync();

            Console.ReadKey();
        }
    }
}
