using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// In-memory data per tenant
var tenantData = new Dictionary<string, List<string>>
{
    { "tenant1", new List<string> { "Product A1", "Product A2" } },
    { "tenant2", new List<string> { "Product B1", "Product B2" } }
};

var app = builder.Build();

// Middleware to get tenant from header
app.Use(async (context, next) =>
{
    if (!context.Request.Headers.TryGetValue("X-Tenant-ID", out var tenantId))
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("Tenant ID header missing!");
        return;
    }

    context.Items["TenantId"] = tenantId.ToString();
    await next();
});

// Endpoint to get tenant-specific products
app.MapGet("/api/products", (HttpContext context) =>
{
    var tenantId = context.Items["TenantId"].ToString();
    if (!tenantData.ContainsKey(tenantId))
        return Results.NotFound(new { message = $"No data for tenant '{tenantId}'" });

    return Results.Ok(tenantData[tenantId]);
});

app.Run();