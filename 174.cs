using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MiniERPConsole
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            // Setup Redis Cache
            var services = new ServiceCollection();
            services.AddStackExchangeRedisCache(options =>
            {
                options.Configuration = "localhost:6379"; // Redis server
                options.InstanceName = "MiniERP:";
            });
            var serviceProvider = services.BuildServiceProvider();
            var cache = serviceProvider.GetRequiredService<IDistributedCache>();

            using HttpClient client = new HttpClient();
            string apiUrl = "https://jsonplaceholder.typicode.com/posts"; // Sample API

            string cacheKey = "productsCache";
            var cachedData = await cache.GetStringAsync(cacheKey);

            List<Product> products;

            if (!string.IsNullOrEmpty(cachedData))
            {
                // Load from Redis cache
                products = JsonSerializer.Deserialize<List<Product>>(cachedData);
                Console.WriteLine("Loaded products from Redis cache.");
            }
            else
            {
                // Fetch from API
                var apiData = await client.GetFromJsonAsync<List<Product>>(apiUrl);
                products = apiData ?? new List<Product>();

                // Store in Redis for 60 seconds
                await cache.SetStringAsync(
                    cacheKey,
                    JsonSerializer.Serialize(products),
                    new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60)
                    });

                Console.WriteLine("Fetched products from API and stored in Redis.");
            }

            // Display products
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Quantity: {p.Quantity}, Price: {p.Price}");
            }
        }
    }
}