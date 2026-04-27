using System;
using System.Threading.Tasks;

class AsyncAwaitExample
{
    // Step 1: Async method that returns a Task<int>
    static async Task<int> CalculateSumAsync(int a, int b)
    {
        Console.WriteLine("Calculation started...");
        await Task.Delay(2000); // Simulate a long-running operation
        return a + b;
    }

    // Step 2: Async method that does not return a value
    static async Task PrintMessageAsync()
    {
        await Task.Delay(1000); // Simulate delay
        Console.WriteLine("Hello from async method!");
    }

    static async Task Main(string[] args)
    {
        // Step 3: Call async methods using await
        Task<int> sumTask = CalculateSumAsync(10, 20);
        Task printTask = PrintMessageAsync();

        // Wait for sumTask to complete and get result
        int result = await sumTask;
        Console.WriteLine("Sum: " + result);

        // Wait for printTask to complete
        await printTask;

        Console.WriteLine("Main method completed.");
    }
}