using System;
using Serilog;

// Custom business exception
public class BusinessException : Exception
{
    public int ErrorCode { get; private set; }

    public BusinessException(string message, int errorCode) : base(message)
    {
        ErrorCode = errorCode;
    }
}

// Centralized exception handler
public static class ExceptionHandler
{
    public static void Handle(Exception ex)
    {
        switch (ex)
        {
            case BusinessException bex:
                Log.Warning("Business exception occurred: {Message} | Code: {Code}", bex.Message, bex.ErrorCode);
                Console.WriteLine($"Business Error: {bex.Message}");
                break;
            case ArgumentNullException argEx:
                Log.Error(argEx, "ArgumentNullException: {Param}", argEx.ParamName);
                Console.WriteLine("Invalid input provided.");
                break;
            default:
                Log.Fatal(ex, "Unhandled exception occurred.");
                Console.WriteLine("An unexpected error occurred. Contact support.");
                break;
        }
    }
}

class Program
{
    static void Main()
    {
        // 1. Configure Serilog
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .WriteTo.File("logs/enterprise_exceptions.json", rollingInterval: RollingInterval.Day, formatter: new Serilog.Formatting.Json.JsonFormatter())
            .CreateLogger();

        Log.Information("Enterprise application started.");

        try
        {
            // Simulate operations
            ProcessOrder(null); // Will throw ArgumentNullException
            ProcessPayment(-100); // Will throw BusinessException
        }
        catch (Exception ex)
        {
            ExceptionHandler.Handle(ex);
        }
        finally
        {
            Log.Information("Application shutting down.");
            Log.CloseAndFlush();
        }
    }

    static void ProcessOrder(string orderId)
    {
        if (string.IsNullOrEmpty(orderId))
            throw new ArgumentNullException(nameof(orderId), "Order ID cannot be null.");
        Log.Information("Processing order {OrderId}", orderId);
    }

    static void ProcessPayment(decimal amount)
    {
        if (amount <= 0)
            throw new BusinessException("Payment amount must be positive.", 1001);

        Log.Information("Processing payment of {Amount}", amount);
    }
}