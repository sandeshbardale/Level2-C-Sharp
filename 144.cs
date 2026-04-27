using System;
using System.Threading.Tasks;

class TPLExample
{
    static void Main(string[] args)
    {
        // Step 1: Create tasks
        Task task1 = Task.Run(() =>
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine("Task 1: " + i);
                Task.Delay(500).Wait(); // Simulate work
            }
        });

        Task task2 = Task.Run(() =>
        {
            for (char c = 'A'; c <= 'E'; c++)
            {
                Console.WriteLine("Task 2: " + c);
                Task.Delay(700).Wait(); // Simulate work
            }
        });

        // Step 2: Wait for tasks to complete
        Task.WaitAll(task1, task2);

        Console.WriteLine("All tasks completed.");
    }
}