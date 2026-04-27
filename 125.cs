using System;
using System.Collections.Generic;

class ListExample
{
    static void Main(string[] args)
    {
        // Creating a List of integers
        List<int> numbers = new List<int>();

        // Adding elements
        numbers.Add(10);
        numbers.Add(20);
        numbers.Add(30);
        numbers.Add(40);

        Console.WriteLine("Elements in List:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // Removing element
        numbers.Remove(20);

        Console.WriteLine("\nAfter removing 20:");
        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }

        // Access by index
        Console.WriteLine("\nElement at index 1: " + numbers[1]);

        // Count
        Console.WriteLine("Total elements: " + numbers.Count);
    }
}