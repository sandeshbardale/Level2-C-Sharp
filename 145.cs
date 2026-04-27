using System;
using System.Threading;

class LockingExample
{
    private static int counter = 0;
    private static object lockObj = new object(); // Lock object

    // Method without lock (can cause race condition)
    static void IncrementWithoutLock()
    {
        for (int i = 0; i < 5; i++)
        {
            counter++;
            Console.WriteLine("Without Lock - Counter: " + counter);
            Thread.Sleep(100); // Simulate work
        }
    }

    // Method with lock (synchronized)
    static void IncrementWithLock()
    {
        for (int i = 0; i < 5; i++)
        {
            lock (lockObj) // Synchronize access
            {
                counter++;
                Console.WriteLine("With Lock - Counter: " + counter);
            }
            Thread.Sleep(100); // Simulate work
        }
    }

    static void Main(string[] args)
    {
        counter = 0;

        Console.WriteLine("=== Without Lock ===");
        Thread t1 = new Thread(IncrementWithoutLock);
        Thread t2 = new Thread(IncrementWithoutLock);

        t1.Start();
        t2.Start();

        t1.Join();
        t2.Join();

        counter = 0;

        Console.WriteLine("\n=== With Lock ===");
        Thread t3 = new Thread(IncrementWithLock);
        Thread t4 = new Thread(IncrementWithLock);

        t3.Start();
        t4.Start();

        t3.Join();
        t4.Join();

        Console.WriteLine("\nFinal Counter Value: " + counter);
    }
}