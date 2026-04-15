using System;

class CommonElementsDemo
{
    static void Main()
    {
        // Input arrays
        int[] array1 = { 1, 2, 3, 4, 5 };
        int[] array2 = { 4, 5, 6, 7, 8 };

        Console.WriteLine("Array 1: " + string.Join(", ", array1));
        Console.WriteLine("Array 2: " + string.Join(", ", array2));

        Console.WriteLine("\nCommon Elements:");

        // Find common elements
        for (int i = 0; i < array1.Length; i++)
        {
            for (int j = 0; j < array2.Length; j++)
            {
                if (array1[i] == array2[j])
                {
                    Console.Write(array1[i] + " ");
                    break; // To avoid duplicate printing
                }
            }
        }
    }
}