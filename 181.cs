using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MiniERPMicroservices
{
    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Mini ERP Microservices Simulation\n");

            // Start InventoryService in background
            var inventoryTask = Task.Run(() => StartInventoryService());

            // Give inventory service time to start
            await Task.Delay(1000);

            // Start OrderService (console input)
            await StartOrderService();
        }

        // InventoryService: simple HTTP listener
        static void StartInventoryService()
        {
            HttpListener listener = new HttpListener();
            listener.Prefixes.Add("http://localhost:8080/inventory/");
            listener.Start();
            Console.WriteLine("[InventoryService] Listening on http://localhost:8080/inventory/");

            while (true)
            {
                var context = listener.GetContext();
                var request = context.Request;

                using var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding);
                var body = reader.ReadToEnd();

                var order = JsonSerializer.Deserialize<Order>(body);
                Console.WriteLine($"[InventoryService] Received order: {order.ProductName}, Qty: {order.Quantity}");

                var response = context.Response;
                string responseString = "{\"status\":\"Inventory updated\"}";
                byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                response.OutputStream.Write(buffer, 0, buffer.Length);
                response.OutputStream.Close();
            }
        }

        // OrderService: send orders to inventory
        static async Task StartOrderService()
        {
            using HttpClient client = new HttpClient();
            string inventoryUrl = "http://localhost:8080/inventory/";

            int orderId = 1;
            while (true)
            {
                Console.Write("Enter product name (or 'exit'): ");
                string product = Console.ReadLine();
                if (product.ToLower() == "exit") break;

                Console.Write("Enter quantity: ");
                int qty = int.Parse(Console.ReadLine());

                var order = new Order { Id = orderId++, ProductName = product, Quantity = qty };
                var json = JsonSerializer.Serialize(order);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(inventoryUrl, content);
                string result = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"[OrderService] Sent order, response: {result}\n");
            }

            Console.WriteLine("Exiting OrderService...");
        }
    }
}