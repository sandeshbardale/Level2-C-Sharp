using System;
using System.Collections.Generic;
using System.Linq;

class FAPExample
{
    static void Main(string[] args)
    {
        // ----------------------------
        // Func<T, TResult> example
        // ----------------------------
        Func<int, int, int> add = (a, b) => a + b;  // Takes 2 ints, returns int
        Console.WriteLine("Func - Sum: " + add(5, 10));

        // ----------------------------
        // Action<T> example
        // ----------------------------
        Action<string> greet = name => Console.WriteLine("Action - Hello, " + name);
        greet("Alice");

        // ----------------------------
        // Predicate<T> example
        // ----------------------------
        Predicate<int> isEven = n => n % 2 == 0;   // Returns bool
        Console.WriteLine("Predicate - 8 is even? " + isEven(8));

        // Using Predicate with List<T>.FindAll
        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6 };
        var evenNumbers = numbers.FindAll(isEven);

        Console.WriteLine("Even numbers in list:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }
}