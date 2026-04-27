using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MiniERPBackgroundWorkerConsole
{
    // Product model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;
    }

    // Background worker
    public class ProductCleanupWorker : BackgroundService
    {
        private readonly ILogger<ProductCleanupWorker> _logger;
        private readonly List<Product> _products;

        public ProductCleanupWorker(ILogger<ProductCleanupWorker> logger, List<Product> products)
        {
            _logger = logger;
            _products = products;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Product Cleanup Worker started at: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    // Simulate cleanup: deactivate products with even Ids
                    foreach (var p in _products)
                    {
                        if (p.Id % 2 == 0 && p.IsActive)
                        {
                            p.IsActive = false;
                            _logger.LogInformation("Product {id} ({name}) deactivated at {time}", p.Id, p.Name, DateTimeOffset.Now);
                        }
                    }

                    await Task.Delay(TimeSpan.FromSeconds(10), stoppingToken); // Runs every 10 seconds
                }
                catch (TaskCanceledException)
                {
                    _logger.LogInformation("Background task cancelled.");
                }
            }

            _logger.LogInformation("Product Cleanup Worker stopped at: {time}", DateTimeOffset.Now);
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Sample product list
            var products = new List<Product>
            {
                new Product{ Id = 1, Name="Laptop" },
                new Product{ Id = 2, Name="Mouse" },
                new Product{ Id = 3, Name="Keyboard" },
                new Product{ Id = 4, Name="Monitor" },
            };

            // Build host
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddSingleton(products); // inject product list
                    services.AddHostedService<ProductCleanupWorker>();
                })
                .Build();

            // Run host (background worker runs automatically)
            await host.RunAsync();
        }
    }
}