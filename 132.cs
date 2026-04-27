using System;
using System.Collections.Generic;
using System.Linq;

class LambdaExample
{
    static void Main(string[] args)
    {
        // Creating a list
        List<int> numbers = new List<int>() { 5, 10, 15, 20, 25 };

        // Using lambda expression with Where (filter)
        var greaterThanTen = numbers.Where(n => n > 10);

        Console.WriteLine("Numbers greater than 10:");
        foreach (var num in greaterThanTen)
        {
            Console.WriteLine(num);
        }

        // Using lambda expression with Select (transform)
        var squares = numbers.Select(n => n * n);

        Console.WriteLine("\nSquares of numbers:");
        foreach (var sq in squares)
        {
            Console.WriteLine(sq);
        }

        // Lambda with single value (Func delegate)
        Func<int, int> cube = x => x * x * x;

        Console.WriteLine("\nCube of 3: " + cube(3));
    }
}