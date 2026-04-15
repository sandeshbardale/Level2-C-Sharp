using System;

class RecursionDemo
{
    // Recursive method to calculate factorial
    static int Factorial(int n)
    {
        if (n <= 1) // Base case
            return 1;
        else
            return n * Factorial(n - 1); // Recursive call
    }

    static void Main()
    {
        Console.Write("Enter a number to find factorial: ");
        int num = int.Parse(Console.ReadLine());

        int result = Factorial(num);
        Console.WriteLine("Factorial of " + num + " is: " + result);
    }
}