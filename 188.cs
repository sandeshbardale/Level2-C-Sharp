using Microsoft.ApplicationInsights.AspNetCore.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure Application Insights
string aiConnectionString = "YOUR_APPLICATION_INSIGHTS_CONNECTION_STRING";
builder.Services.AddApplicationInsightsTelemetry(new ApplicationInsightsServiceOptions
{
    ConnectionString = aiConnectionString
});

// In-memory product list
var products = new List<Product>
{
    new Product { Id = 1, Name = "Laptop", Quantity = 5 },
    new Product { Id = 2, Name = "Mouse", Quantity = 20 }
};

var app = builder.Build();

// API Endpoints
app.MapGet("/api/products", () => products);

app.MapPost("/api/products", (Product product) =>
{
    product.Id = products.Count + 1;
    products.Add(product);
    return Results.Ok(product);
});

app.MapGet("/api/performance-test", () =>
{
    // Simulate heavy processing
    var watch = System.Diagnostics.Stopwatch.StartNew();
    System.Threading.Thread.Sleep(500); // simulate work
    watch.Stop();
    return Results.Ok(new { message = "Performance test completed", elapsedMs = watch.ElapsedMilliseconds });
});

app.Run();

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}