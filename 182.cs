using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;

namespace MiniERPDockerConsole
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configure services
            builder.Services.AddControllers();
            builder.Services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.WriteIndented = true;
            });

            // In-memory product list
            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", Quantity = 5 },
                new Product { Id = 2, Name = "Mouse", Quantity = 20 }
            };
            builder.Services.AddSingleton(products);

            var app = builder.Build();

            // Map endpoints
            app.MapGet("/api/products", (List<Product> prods) => prods);

            app.MapPost("/api/products", (List<Product> prods, Product product) =>
            {
                product.Id = prods.Count + 1;
                prods.Add(product);
                return Results.Ok(product);
            });

            app.MapPut("/api/products/{id}", (List<Product> prods, int id, Product product) =>
            {
                var existing = prods.Find(p => p.Id == id);
                if (existing == null) return Results.NotFound();
                existing.Name = product.Name;
                existing.Quantity = product.Quantity;
                return Results.Ok(existing);
            });

            app.MapDelete("/api/products/{id}", (List<Product> prods, int id) =>
            {
                var existing = prods.Find(p => p.Id == id);
                if (existing == null) return Results.NotFound();
                prods.Remove(existing);
                return Results.Ok(existing);
            });

            app.Run();
        }
    }
}