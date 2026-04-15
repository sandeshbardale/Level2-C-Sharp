using System;

class Program
{
    // Method using ref keyword
    static void AddTen(ref int num)
    {
        num = num + 10;
    }

    // Method using out keyword
    static void GetValues(out int a, out int b)
    {
        a = 20;
        b = 30;
    }

    static void Main(string[] args)
    {
        // Demonstrating ref
        int number = 5;
        Console.WriteLine("Before using ref: " + number);

        AddTen(ref number);

        Console.WriteLine("After using ref: " + number);

        // Demonstrating out
        int x, y;
        GetValues(out x, out y);

        Console.WriteLine("Values returned using out:");
        Console.WriteLine("x = " + x);
        Console.WriteLine("y = " + y);

        Console.ReadLine();
    }
}