using System;

// Static class
static class Calculator
{
    // Static method
    public static int Add(int a, int b)
    {
        return a + b;
    }

    public static int Multiply(int a, int b)
    {
        return a * b;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Accessing static methods without creating object
        int sum = Calculator.Add(10, 20);
        int product = Calculator.Multiply(5, 4);

        Console.WriteLine("Sum: " + sum);
        Console.WriteLine("Product: " + product);

        Console.ReadLine();
    }
}