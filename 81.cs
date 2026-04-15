using System;

class Program
{
    // Method that accepts an array as parameter
    static void DisplayArray(int[] arr)
    {
        Console.WriteLine("Elements of the array:");

        foreach (int num in arr)
        {
            Console.WriteLine(num);
        }
    }

    static void Main(string[] args)
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        // Passing array to method
        DisplayArray(numbers);

        Console.ReadLine();
    }
}