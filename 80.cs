
using System;

class Program
{
    // Static method
    static void DisplayMessage()
    {
        Console.WriteLine("This is a static method.");
    }

    // Another static method
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static void Main(string[] args)
    {
        // Calling static methods
        DisplayMessage();

        int result = AddNumbers(10, 20);
        Console.WriteLine("Sum = " + result);

        Console.ReadLine();
    }
}