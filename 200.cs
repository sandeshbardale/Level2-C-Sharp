using System;
using Serilog;

class Program
{
    static void Main()
    {
        // Configure structured logging
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File("logs/app_deploy_log.txt", rollingInterval: RollingInterval.Day)
            .CreateLogger();

        Log.Information("Starting MyApp...");

        try
        {
            Console.WriteLine("Hello, this is your deployed .NET application!");
            Log.Information("Application ran successfully at {Time}", DateTime.UtcNow);

            // Simulate some operation
            int result = Divide(10, 2);
            Console.WriteLine($"Result of division: {result}");
        }
        catch (Exception ex)
        {
            Log.Error(ex, "An unexpected error occurred.");
            Console.WriteLine("Something went wrong. Check logs for details.");
        }
        finally
        {
            Log.Information("Application shutting down.");
            Log.CloseAndFlush();
        }
    }

    static int Divide(int a, int b)
    {
        if (b == 0)
            throw new DivideByZeroException("Divider cannot be zero.");
        return a / b;
    }
}