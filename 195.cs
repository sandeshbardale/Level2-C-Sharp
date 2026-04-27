using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// ------------------- Event Bus -------------------
public interface IEvent { }

public class ProductCreatedEvent : IEvent
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
}

public interface IEventBus
{
    void Publish(IEvent @event);
    void Subscribe<TEvent>(Func<TEvent, Task> handler) where TEvent : IEvent;
}

public class InMemoryEventBus : IEventBus
{
    private readonly Dictionary<Type, List<Func<IEvent, Task>>> _handlers = new();

    public void Publish(IEvent @event)
    {
        var type = @event.GetType();
        if (_handlers.ContainsKey(type))
        {
            foreach (var handler in _handlers[type])
            {
                handler(@event); // fire and forget
            }
        }
    }

    public void Subscribe<TEvent>(Func<TEvent, Task> handler) where TEvent : IEvent
    {
        var type = typeof(TEvent);
        if (!_handlers.ContainsKey(type)) _handlers[type] = new List<Func<IEvent, Task>>();
        _handlers[type].Add(e => handler((TEvent)e));
    }
}

// ------------------- Domain -------------------
public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

// ------------------- Application -------------------
public class ProductService
{
    private readonly List<Product> _products = new();
    private readonly IEventBus _eventBus;

    public ProductService(IEventBus eventBus)
    {
        _eventBus = eventBus;
    }

    public Product AddProduct(Product product)
    {
        product.Id = _products.Count + 1;
        _products.Add(product);

        // Raise event
        _eventBus.Publish(new ProductCreatedEvent { ProductId = product.Id, ProductName = product.Name });
        return product;
    }

    public List<Product> GetAll() => _products;
}

// ------------------- Minimal API -------------------
var builder = WebApplication.CreateBuilder(args);

// Dependency Injection
builder.Services.AddSingleton<IEventBus, InMemoryEventBus>();
builder.Services.AddSingleton<ProductService>();

var app = builder.Build();

// Subscribe to events
var eventBus = app.Services.GetRequiredService<IEventBus>();
eventBus.Subscribe<ProductCreatedEvent>(async e =>
{
    Console.WriteLine($"[EVENT RECEIVED] Product Created: {e.ProductName} (ID: {e.ProductId})");
    await Task.CompletedTask;
});

// Endpoints
app.MapGet("/products", (ProductService service) => service.GetAll());

app.MapPost("/products", (Product product, ProductService service) =>
{
    var added = service.AddProduct(product);
    return Results.Ok(added);
});

app.Run();