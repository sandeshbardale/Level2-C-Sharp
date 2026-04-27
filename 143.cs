using System;
using System.Threading;

class MultithreadingExample
{
    // Method to be executed on a thread
    static void PrintNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Thread 1: " + i);
            Thread.Sleep(500); // Pause for 500ms
        }
    }

    static void PrintLetters()
    {
        for (char c = 'A'; c <= 'E'; c++)
        {
            Console.WriteLine("Thread 2: " + c);
            Thread.Sleep(700); // Pause for 700ms
        }
    }

    static void Main(string[] args)
    {
        // Step 1: Create threads
        Thread thread1 = new Thread(PrintNumbers);
        Thread thread2 = new Thread(PrintLetters);

        // Step 2: Start threads
        thread1.Start();
        thread2.Start();

        // Step 3: Wait for threads to complete
        thread1.Join();
        thread2.Join();

        Console.WriteLine("Main thread completed.");
    }
}