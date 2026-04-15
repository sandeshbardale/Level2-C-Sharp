using System;

class FactorialRecursion
{
    // Recursive method to calculate factorial
    static long Factorial(int n)
    {
        if (n <= 1) // Base case
            return 1;
        else
            return n * Factorial(n - 1); // Recursive call
    }

    static void Main()
    {
        Console.Write("Enter a number: ");
        int num = int.Parse(Console.ReadLine());

        long result = Factorial(num);
        Console.WriteLine("Factorial of " + num + " is: " + result);
    }
}