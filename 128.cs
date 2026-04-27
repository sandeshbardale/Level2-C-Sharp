using System;
using System.Collections.Generic;
using System.Linq;

class LINQExample
{
    static void Main(string[] args)
    {
        // Creating a list
        List<int> numbers = new List<int>() { 10, 15, 20, 25, 30 };

        // Using Where to filter even numbers
        var evenNumbers = numbers.Where(n => n % 2 == 0);

        Console.WriteLine("Even Numbers:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }

        // Using Select to transform data (square of numbers)
        var squares = numbers.Select(n => n * n);

        Console.WriteLine("\nSquares of Numbers:");
        foreach (var sq in squares)
        {
            Console.WriteLine(sq);
        }
    }
}