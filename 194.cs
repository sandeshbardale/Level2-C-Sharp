using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ------------------- In-Memory Storage -------------------
var products = new List<Product>();

var builder = WebApplication.CreateBuilder(args);

// ------------------- Services -------------------
builder.Services.AddSingleton<IProductCommandHandler, ProductCommandHandler>();
builder.Services.AddSingleton<IProductQueryHandler, ProductQueryHandler>();

var app = builder.Build();

// ------------------- Queries (Read) -------------------
app.MapGet("/products", (IProductQueryHandler queryHandler) => queryHandler.GetAllProducts());
app.MapGet("/products/{id}", (int id, IProductQueryHandler queryHandler) =>
{
    var product = queryHandler.GetProductById(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

// ------------------- Commands (Write) -------------------
app.MapPost("/products", (Product product, IProductCommandHandler commandHandler) =>
{
    commandHandler.AddProduct(product);
    return Results.Ok(product);
});

app.MapPut("/products/{id}", (int id, Product product, IProductCommandHandler commandHandler) =>
{
    var updated = commandHandler.UpdateProduct(id, product);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/products/{id}", (int id, IProductCommandHandler commandHandler) =>
{
    var deleted = commandHandler.DeleteProduct(id);
    return deleted ? Results.Ok(new { message = "Deleted" }) : Results.NotFound();
});

app.Run();

// ------------------- Domain -------------------
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// ------------------- Query Handler -------------------
public interface IProductQueryHandler
{
    List<Product> GetAllProducts();
    Product GetProductById(int id);
}

public class ProductQueryHandler : IProductQueryHandler
{
    public List<Product> GetAllProducts() => products.ToList();
    public Product GetProductById(int id) => products.FirstOrDefault(p => p.Id == id);
}

// ------------------- Command Handler -------------------
public interface IProductCommandHandler
{
    Product AddProduct(Product product);
    Product UpdateProduct(int id, Product product);
    bool DeleteProduct(int id);
}

public class ProductCommandHandler : IProductCommandHandler
{
    public Product AddProduct(Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);
        return product;
    }

    public Product UpdateProduct(int id, Product product)
    {
        var existing = products.FirstOrDefault(p => p.Id == id);
        if (existing == null) return null;
        existing.Name = product.Name;
        existing.Quantity = product.Quantity;
        return existing;
    }

    public bool DeleteProduct(int id)
    {
        var existing = products.FirstOrDefault(p => p.Id == id);
        if (existing == null) return false;
        products.Remove(existing);
        return true;
    }
}