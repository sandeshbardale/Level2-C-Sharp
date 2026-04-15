using System;

class FibonacciRecursion
{
    // Recursive method to find nth Fibonacci number
    static int Fibonacci(int n)
    {
        if (n == 0) // Base case 1
            return 0;
        else if (n == 1) // Base case 2
            return 1;
        else
            return Fibonacci(n - 1) + Fibonacci(n - 2); // Recursive call
    }

    static void Main()
    {
        Console.Write("Enter the number of terms: ");
        int terms = int.Parse(Console.ReadLine());

        Console.WriteLine("Fibonacci series:");
        for (int i = 0; i < terms; i++)
        {
            Console.Write(Fibonacci(i) + " ");
        }
    }
}