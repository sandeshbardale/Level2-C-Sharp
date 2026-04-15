using System;

class TransposeMatrix
{
    static void Main()
    {
        int i, j;
        int[,] matrix = new int[3, 3];

        Console.WriteLine("Enter elements of 3x3 matrix:");

        // Input matrix
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                Console.Write("Element [" + i + "," + j + "]: ");
                matrix[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nOriginal Matrix:");
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nTranspose of Matrix:");
        for (i = 0; i < 3; i++)
        {
            for (j = 0; j < 3; j++)
            {
                Console.Write(matrix[j, i] + "\t");
            }
            Console.WriteLine();
        }
    }
}