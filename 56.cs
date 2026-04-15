using System;

class Program
{
    static void Main()
    {
        Console.Write("Enter size of first array: ");
        int n1 = Convert.ToInt32(Console.ReadLine());

        int[] arr1 = new int[n1];

        for (int i = 0; i < n1; i++)
        {
            Console.Write("Enter element " + (i + 1) + " of first array: ");
            arr1[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("\nEnter size of second array: ");
        int n2 = Convert.ToInt32(Console.ReadLine());

        int[] arr2 = new int[n2];

        for (int i = 0; i < n2; i++)
        {
            Console.Write("Enter element " + (i + 1) + " of second array: ");
            arr2[i] = Convert.ToInt32(Console.ReadLine());
        }

        // Merging arrays
        int[] merged = new int[n1 + n2];

        for (int i = 0; i < n1; i++)
        {
            merged[i] = arr1[i];
        }

        for (int i = 0; i < n2; i++)
        {
            merged[n1 + i] = arr2[i];
        }

        Console.WriteLine("\nMerged Array:");
        foreach (int num in merged)
        {
            Console.WriteLine(num);
        }

        Console.ReadLine();
    }
}