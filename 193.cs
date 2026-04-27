using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// ------------------- Infrastructure -------------------
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// ------------------- API Endpoints -------------------
app.MapGet("/products", async (ProductService service) => await service.GetAllAsync());

app.MapGet("/products/{id}", async (int id, ProductService service) =>
{
    var product = await service.GetByIdAsync(id);
    return product is null ? Results.NotFound() : Results.Ok(product);
});

app.MapPost("/products", async (Product product, ProductService service) => Results.Ok(await service.AddAsync(product)));

app.MapPut("/products/{id}", async (int id, Product product, ProductService service) =>
{
    product.Id = id;
    var updated = await service.UpdateAsync(product);
    return updated is null ? Results.NotFound() : Results.Ok(updated);
});

app.MapDelete("/products/{id}", async (int id, ProductService service) =>
{
    await service.DeleteAsync(id);
    return Results.Ok(new { message = "Deleted" });
});

app.Run();

// ------------------- Domain Layer -------------------
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// ------------------- Application Layer -------------------
public interface IProductRepository
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(int id);
    Task<Product> AddAsync(Product product);
    Task<Product> UpdateAsync(Product product);
    Task DeleteAsync(int id);
}

public class ProductService
{
    private readonly IProductRepository _repo;
    public ProductService(IProductRepository repo) => _repo = repo;

    public Task<List<Product>> GetAllAsync() => _repo.GetAllAsync();
    public Task<Product> GetByIdAsync(int id) => _repo.GetByIdAsync(id);
    public Task<Product> AddAsync(Product product) => _repo.AddAsync(product);
    public Task<Product> UpdateAsync(Product product) => _repo.UpdateAsync(product);
    public Task DeleteAsync(int id) => _repo.DeleteAsync(id);
}

// ------------------- Infrastructure Layer -------------------
public class ProductRepository : IProductRepository
{
    private readonly List<Product> _products = new();

    public Task<Product> AddAsync(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task DeleteAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null) _products.Remove(product);
        return Task.CompletedTask;
    }

    public Task<List<Product>> GetAllAsync() => Task.FromResult(_products.ToList());

    public Task<Product> GetByIdAsync(int id) => Task.FromResult(_products.FirstOrDefault(p => p.Id == id));

    public Task<Product> UpdateAsync(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Quantity = product.Quantity;
        }
        return Task.FromResult(existing);
    }
}