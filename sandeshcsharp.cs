using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter number of elements: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        // Reading array elements
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element " + (i + 1) + ": ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Displaying array elements
        Console.WriteLine("\nArray elements are:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(arr[i]);
        }

        Console.ReadLine();
    }
}