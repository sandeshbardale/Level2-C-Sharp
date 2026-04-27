using System;
using System.Collections.Generic;
using System.Linq;

class AggregateExample
{
    static void Main(string[] args)
    {
        // Creating a list of numbers
        List<int> numbers = new List<int>() { 1, 2, 3, 4, 5 };

        // Using Aggregate to calculate sum
        int sum = numbers.Aggregate((a, b) => a + b);

        Console.WriteLine("Sum of numbers: " + sum);

        // Using Aggregate to calculate product
        int product = numbers.Aggregate((a, b) => a * b);

        Console.WriteLine("Product of numbers: " + product);
    }
}