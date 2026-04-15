using System;

class MissingNumberDemo
{
    static void Main()
    {
        // Example array with numbers from 1 to 10, missing 7
        int[] array = { 1, 2, 3, 4, 5, 6, 8, 9, 10 };
        int n = 10; // Maximum number in sequence

        int sumOfArray = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sumOfArray += array[i];
        }

        // Sum of first n natural numbers
        int totalSum = n * (n + 1) / 2;

        int missingNumber = totalSum - sumOfArray;

        Console.WriteLine("The missing number is: " + missingNumber);
    }
}