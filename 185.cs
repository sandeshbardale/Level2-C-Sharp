using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Configure Azure SQL connection
builder.Services.AddDbContext<MiniERPContext>(options =>
    options.UseSqlServer("Server=tcp:yourserver.database.windows.net,1433;Initial Catalog=MiniERPDB;Persist Security Info=False;User ID=youruser;Password=yourpassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));

// Enable controllers
builder.Services.AddControllers();

var app = builder.Build();

// Migrate database on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MiniERPContext>();
    db.Database.Migrate();
}

// Map CRUD endpoints
app.MapGet("/api/products", async (MiniERPContext db) =>
    await db.Products.ToListAsync());

app.MapPost("/api/products", async (MiniERPContext db, Product product) =>
{
    db.Products.Add(product);
    await db.SaveChangesAsync();
    return Results.Ok(product);
});

app.MapPut("/api/products/{id}", async (MiniERPContext db, int id, Product product) =>
{
    var existing = await db.Products.FindAsync(id);
    if (existing == null) return Results.NotFound();
    existing.Name = product.Name;
    existing.Quantity = product.Quantity;
    await db.SaveChangesAsync();
    return Results.Ok(existing);
});

app.MapDelete("/api/products/{id}", async (MiniERPContext db, int id) =>
{
    var existing = await db.Products.FindAsync(id);
    if (existing == null) return Results.NotFound();
    db.Products.Remove(existing);
    await db.SaveChangesAsync();
    return Results.Ok(existing);
});

app.Run();

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Quantity { get; set; }
}

// DbContext for Azure SQL
public class MiniERPContext : DbContext
{
    public MiniERPContext(DbContextOptions<MiniERPContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}