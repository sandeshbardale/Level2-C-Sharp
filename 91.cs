using System;

class JaggedArrayDemo
{
    static void Main()
    {
        // Declare a jagged array with 3 rows
        int[][] jaggedArray = new int[3][];

        // Initialize each row with different sizes
        jaggedArray[0] = new int[2] { 1, 2 };
        jaggedArray[1] = new int[3] { 3, 4, 5 };
        jaggedArray[2] = new int[4] { 6, 7, 8, 9 };

        // Display the jagged array
        Console.WriteLine("Jagged Array Elements:");
        for (int i = 0; i < jaggedArray.Length; i++)
        {
            for (int j = 0; j < jaggedArray[i].Length; j++)
            {
                Console.Write(jaggedArray[i][j] + " ");
            }
            Console.WriteLine();
        }
    }
}