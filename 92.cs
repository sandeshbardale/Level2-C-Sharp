using System;

class MultiDimensionalArrayDemo
{
    static void Main()
    {
        // Declare and initialize a 2D array (3 rows x 4 columns)
        int[,] multiArray = {
            {1, 2, 3, 4},
            {5, 6, 7, 8},
            {9, 10, 11, 12}
        };

        // Display the array
        Console.WriteLine("Multidimensional Array Elements:");
        for (int i = 0; i < multiArray.GetLength(0); i++) // Rows
        {
            for (int j = 0; j < multiArray.GetLength(1); j++) // Columns
            {
                Console.Write(multiArray[i, j] + " ");
            }
            Console.WriteLine();
        }

        // Accessing a specific element
        Console.WriteLine("\nElement at row 2, column 3: " + multiArray[1, 2]);
    }
}