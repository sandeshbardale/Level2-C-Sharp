using System;
using System.Collections.Generic;

class StackExample
{
    static void Main(string[] args)
    {
        // Creating a Stack
        Stack<int> stack = new Stack<int>();

        // Pushing elements
        stack.Push(10);
        stack.Push(20);
        stack.Push(30);

        Console.WriteLine("Stack elements:");

        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }

        // Pop (removes top element)
        Console.WriteLine("\nPopped element: " + stack.Pop());

        // Peek (view top element)
        Console.WriteLine("Top element: " + stack.Peek());

        Console.WriteLine("\nStack after pop:");
        foreach (int item in stack)
        {
            Console.WriteLine(item);
        }

        // Count
        Console.WriteLine("\nTotal elements: " + stack.Count);
    }
}