using System;

class Demo
{
    // Constructor
    public Demo()
    {
        Console.WriteLine("Constructor called.");
    }

    // Destructor
    ~Demo()
    {
        Console.WriteLine("Destructor called.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Demo obj = new Demo();

        Console.WriteLine("Inside Main method.");

        // Force garbage collection (for demonstration only)
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("End of Main method.");
        Console.ReadLine();
    }
}