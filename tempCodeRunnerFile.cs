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

        int largest = arr[0];
        int smallest = arr[0];

        // Finding largest and smallest
        for (int i = 1; i < n; i++)
        {
            if (arr[i] > largest)
                largest = arr[i];

            if (arr[i] < smallest)
                smallest = arr[i];
        }

        Console.WriteLine("\nLargest element = " + largest);
        Console.WriteLine("Smallest element = " + smallest);

        Console.ReadLine();
    }
}