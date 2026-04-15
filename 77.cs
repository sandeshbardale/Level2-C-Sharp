using System;

class Program
{
    // Method using params keyword
    static int Sum(params int[] numbers)
    {
        int total = 0;

        foreach (int num in numbers)
        {
            total += num;
        }

        return total;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Sum of numbers: " + Sum(10, 20, 30));
        Console.WriteLine("Sum of numbers: " + Sum(5, 10));
        Console.WriteLine("Sum of numbers: " + Sum(1, 2, 3, 4, 5));

        Console.ReadLine();
    }
}