using System;

class MethodOverloadingDemo
{
    // Method with one integer parameter
    static void Display(int a)
    {
        Console.WriteLine("Integer value: " + a);
    }

    // Method with one string parameter
    static void Display(string s)
    {
        Console.WriteLine("String value: " + s);
    }

    // Method with two integer parameters
    static void Display(int a, int b)
    {
        Console.WriteLine("Sum of two integers: " + (a + b));
    }

    static void Main()
    {
        // Calling different overloaded methods
        Display(10);           // Calls method with int
        Display("Hello");      // Calls method with string
        Display(5, 15);        // Calls method with two ints
    }
}