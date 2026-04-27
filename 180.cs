using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace MiniERPSignalRConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Mini ERP SignalR Real-Time Demo");

            // Connect to SignalR hub
            var connection = new HubConnectionBuilder()
                .WithUrl("https://localhost:5001/orderHub") // Change to your hub URL
                .WithAutomaticReconnect()
                .Build();

            // Receive messages from the hub
            connection.On<string>("ReceiveOrder", message =>
            {
                Console.WriteLine($"[Notification] {message}");
            });

            await connection.StartAsync();
            Console.WriteLine("Connected to SignalR hub!");

            // Send orders from console input
            while (true)
            {
                Console.Write("Enter new order (or 'exit' to quit): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "exit") break;

                // Send order message to hub
                await connection.InvokeAsync("BroadcastOrder", input);
                Console.WriteLine("[Sent] Order broadcasted.");
            }

            await connection.StopAsync();
            Console.WriteLine("Disconnected from hub.");
        }
    }
}