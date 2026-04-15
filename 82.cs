using System;

class Program
{
    static void Main(string[] args)
    {
        int[] arr = { 10, 25, 8, 40, 15 };

        int largest = arr[0];
        int secondLargest = arr[0];

        // Find largest element
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] > largest)
            {
                largest = arr[i];
            }
        }

        // Find second largest element
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] > secondLargest && arr[i] < largest)
            {
                secondLargest = arr[i];
            }
        }

        Console.WriteLine("Second Largest Element: " + secondLargest);

        Console.ReadLine();
    }
}