using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];
        int sum = 0;

        // Reading array elements
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
            sum += arr[i];   // Adding elements
        }

        double average = (double)sum / n;

        Console.WriteLine("\nSum = " + sum);
        Console.WriteLine("Average = " + average);

        Console.ReadLine();
    }
}