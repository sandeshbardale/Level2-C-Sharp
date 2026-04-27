using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// ------------------- Domain -------------------
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// ------------------- Service -------------------
public class ProductService
{
    private readonly List<Product> _products = new();
    private readonly IMemoryCache _cache;

    public ProductService(IMemoryCache cache)
    {
        _cache = cache;
    }

    // High-performance async get all with caching
    public async Task<List<Product>> GetAllAsync()
    {
        return await _cache.GetOrCreateAsync("products_cache", async entry =>
        {
            entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(5);
            await Task.Delay(50); // simulate async DB call
            return _products.ToList();
        });
    }

    public Task<Product> GetByIdAsync(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }

    public Task<Product> AddAsync(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);
        _cache.Remove("products_cache"); // invalidate cache
        return Task.FromResult(product);
    }

    public Task<Product> UpdateAsync(int id, Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Quantity = product.Quantity;
            _cache.Remove("products_cache"); // invalidate cache
        }
        return Task.FromResult(existing);
    }

    public Task<bool> DeleteAsync(int id)
    {
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing != null)
        {
            _products.Remove(existing);
            _cache.Remove("products_cache"); // invalidate cache
            return Task.FromResult(true);
        }
        return Task.FromResult(false);
    }
}

