using System;
using Microsoft.Extensions.DependencyInjection;

// Logger interface
public interface ILoggerService
{
    void Log(string message);
}

// Console logger implementation
public class ConsoleLogger : ILoggerService
{
    public void Log(string message)
    {
        Console.WriteLine($"[LOG] {message}");
    }
}

// Business service interface
public interface IEmployeeService
{
    void AddEmployee(string name);
}

// Employee service implementation
public class EmployeeService : IEmployeeService
{
    private readonly ILoggerService _logger;

    // Dependency injected via constructor
    public EmployeeService(ILoggerService logger)
    {
        _logger = logger;
    }

    public void AddEmployee(string name)
    {
        _logger.Log($"Employee '{name}' added successfully.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 1. Setup DI container
        var serviceProvider = new ServiceCollection()
            .AddSingleton<ILoggerService, ConsoleLogger>()     // Register Logger
            .AddSingleton<IEmployeeService, EmployeeService>() // Register EmployeeService
            .BuildServiceProvider();

        // 2. Resolve the EmployeeService
        var employeeService = serviceProvider.GetService<IEmployeeService>();

        Console.Write("Enter employee name to add: ");
        string name = Console.ReadLine();

        employeeService.AddEmployee(name);

        Console.WriteLine("\nPress Enter to exit...");
        Console.ReadLine();
    }
}