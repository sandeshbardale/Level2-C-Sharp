using System;
using Serilog;

namespace LoggingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\app_log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Console.WriteLine("=== Serilog Logging System ===\n");

            try
            {
                Log.Information("Application started.");

                Console.Write("Enter a number: ");
                int num = int.Parse(Console.ReadLine());
                Log.Debug("User entered number {Number}", num);

                int result = 100 / num;
                Log.Information("Division result: {Result}", result);

                Console.WriteLine($"Division Result: {result}");
            }
            catch (DivideByZeroException ex)
            {
                Log.Error(ex, "Attempted division by zero!");
                Console.WriteLine("Error: Division by zero is not allowed.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "An unexpected error occurred.");
                Console.WriteLine("An unexpected error occurred. Check logs for details.");
            }
            finally
            {
                Log.Information("Application ended.");
                Log.CloseAndFlush();
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}