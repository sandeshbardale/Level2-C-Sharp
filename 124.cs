using System;
using System.Collections;

class ArrayListExample
{
    static void Main(string[] args)
    {
        // Creating an ArrayList
        ArrayList list = new ArrayList();

        // Adding elements
        list.Add(10);
        list.Add("Hello");
        list.Add(25.5);
        list.Add(true);

        Console.WriteLine("Elements in ArrayList:");

        // Display elements
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        // Removing an element
        list.Remove("Hello");

        Console.WriteLine("\nAfter removing 'Hello':");
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }

        // Accessing element by index
        Console.WriteLine("\nElement at index 1: " + list[1]);

        // Count of elements
        Console.WriteLine("\nTotal elements: " + list.Count);
    }
}