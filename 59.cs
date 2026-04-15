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

        Console.Write("\nEnter element to search: ");
        int search = Convert.ToInt32(Console.ReadLine());

        bool found = false;

        // Searching element
        for (int i = 0; i < n; i++)
        {
            if (arr[i] == search)
            {
                Console.WriteLine("Element found at position: " + (i + 1));
                found = true;
                break;
            }
        }

        if (!found)
        {
            Console.WriteLine("Element not found in the array.");
        }

        Console.ReadLine();
    }
}