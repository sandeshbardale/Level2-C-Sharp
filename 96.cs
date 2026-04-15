using System;

class DuplicateElements
{
    static void Main()
    {
        int[] array = { 1, 2, 3, 2, 4, 5, 3, 6 };

        Console.WriteLine("Array: " + string.Join(", ", array));
        Console.WriteLine("Duplicate elements:");

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] == array[j])
                {
                    Console.Write(array[i] + " ");
                    break; // To avoid printing the same duplicate again
                }
            }
        }
    }
}