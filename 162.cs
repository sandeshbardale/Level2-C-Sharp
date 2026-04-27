
using System;
using Microsoft.Extensions.Configuration;

namespace ConfigManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            // Build configuration
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Read AppSettings
            var appName = config["AppSettings:ApplicationName"];
            var version = config["AppSettings:Version"];

            Console.WriteLine($"Application: {appName}");
            Console.WriteLine($"Version: {version}");

            // Read Database Settings
            var dbServer = config["Database:Server"];
            var dbName = config["Database:Database"];
            var dbUser = config["Database:User"];
            var dbPass = config["Database:Password"];

            Console.WriteLine("\nDatabase Configuration:");
            Console.WriteLine($"Server: {dbServer}");
            Console.WriteLine($"Database: {dbName}");
            Console.WriteLine($"User: {dbUser}");
            Console.WriteLine($"Password: {dbPass}");

            // Read Logging Settings
            var logLevel = config["Logging:LogLevel"];
            Console.WriteLine($"\nLogging Level: {logLevel}");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}