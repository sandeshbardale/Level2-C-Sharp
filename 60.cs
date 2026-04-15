using System;

class Program
{
    static void Main()
    {
        int r1, c1, r2, c2;

        Console.Write("Enter rows of first matrix: ");
        r1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter columns of first matrix: ");
        c1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter rows of second matrix: ");
        r2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter columns of second matrix: ");
        c2 = Convert.ToInt32(Console.ReadLine());

        if (c1 != r2)
        {
            Console.WriteLine("Matrix multiplication not possible.");
            return;
        }

        int[,] matrix1 = new int[r1, c1];
        int[,] matrix2 = new int[r2, c2];
        int[,] result = new int[r1, c2];

        Console.WriteLine("\nEnter elements of First Matrix:");
        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c1; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix1[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        Console.WriteLine("\nEnter elements of Second Matrix:");
        for (int i = 0; i < r2; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix2[i, j] = Convert.ToInt32(Console.ReadLine());
            }
        }

        // Matrix Multiplication
        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                result[i, j] = 0;
                for (int k = 0; k < c1; k++)
                {
                    result[i, j] += matrix1[i, k] * matrix2[k, j];
                }
            }
        }

        Console.WriteLine("\nResultant Matrix after Multiplication:");
        for (int i = 0; i < r1; i++)
        {
            for (int j = 0; j < c2; j++)
            {
                Console.Write(result[i, j] + "\t");
            }
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}