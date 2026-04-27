using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace MiniERPConsole
{
    // Product model
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    class Program
    {
        // In-memory cache
        private static readonly MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        private const string CacheKey = "productsCache";

        static async Task Main(string[] args)
        {
            Console.WriteLine("Mini ERP Console App with API + Caching\n");

            // URL of sample API (you can replace with your own)
            string apiUrl = "https://dummyjson.com/products"; 

            // Check cache first
            if (!_cache.TryGetValue(CacheKey, out List<Product> products))
            {
                Console.WriteLine("Fetching products from API...");

                using HttpClient client = new HttpClient();
                var response = await client.GetFromJsonAsync<ApiResponse>(apiUrl);

                products = response?.Products ?? new List<Product>();

                // Cache products for 60 seconds
                _cache.Set(CacheKey, products, TimeSpan.FromSeconds(60));
            }
            else
            {
                Console.WriteLine("Loaded products from cache.");
            }

            // Display products
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Qty: {p.Quantity}, Price: {p.Price}");
            }

            // Simple CRUD demonstration
            Console.WriteLine("\nAdding a new product to list...");
            var newProduct = new Product { Id = products.Count + 1, Name = "Keyboard", Quantity = 20, Price = 1200 };
            products.Add(newProduct);

            // Update cache
            _cache.Set(CacheKey, products, TimeSpan.FromSeconds(60));
            Console.WriteLine("Product added and cache updated!");

            Console.WriteLine("\nUpdated Product List:");
            foreach (var p in products)
            {
                Console.WriteLine($"ID: {p.Id}, Name: {p.Name}, Qty: {p.Quantity}, Price: {p.Price}");
            }
        }

        // Helper class for dummy API
        public class ApiResponse
        {
            public List<Product> Products { get; set; }
        }
    }
}