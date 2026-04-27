using System;
using System.Threading.Tasks;
using Serilog;
using Serilog.Formatting.Json;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;

class Program
{
    static async Task Main(string[] args)
    {
        // 1. Configure Serilog (Structured logging)
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File(new JsonFormatter(), "logs/app_log.json", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Application starting...");

        try
        {
            // 2. Setup a basic host for health checks & monitoring
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Health check: always healthy for demo
                    services.AddHealthChecks()
                        .AddCheck("Demo_Health", () => HealthCheckResult.Healthy("OK"));
                })
                .Build();

            // 3. Run health check
            var health = host.Services.GetRequiredService<HealthCheckService>();
            var result = await health.CheckHealthAsync();

            Log.Information("Health Check Status: {Status}", result.Status);

            // 4. Simulate application operations
            Log.Information("Starting operations...");
            PerformOperations();

            Log.Information("Operations completed successfully.");
        }
        catch (Exception ex)
        {
            // 5. Log critical errors
            Log.Fatal(ex, "Application crashed!");
        }
        finally
        {
            Log.Information("Application shutting down...");
            Log.CloseAndFlush();
        }
    }

    static void PerformOperations()
    {
        try
        {
            Log.Debug("Simulating risky operation...");
            int x = 10;
            int y = 0;

            // Simulate error
            int z = x / y;
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Error during operation");
        }
    }
}