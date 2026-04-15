using System;

class CompareStrings
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        // Method 1: Using Equals (case-sensitive)
        if (str1.Equals(str2))
            Console.WriteLine("Strings are equal (case-sensitive).");
        else
            Console.WriteLine("Strings are not equal (case-sensitive).");

        // Method 2: Using Equals with ignore case
        if (str1.Equals(str2, StringComparison.OrdinalIgnoreCase))
            Console.WriteLine("Strings are equal (case-insensitive).");
        else
            Console.WriteLine("Strings are not equal (case-insensitive).");

        // Method 3: Using Compare method
        int result = string.Compare(str1, str2, true); // true for case-insensitive
        if (result == 0)
            Console.WriteLine("Strings are equal (using Compare).");
        else if (result < 0)
            Console.WriteLine("First string is less than second string.");
        else
            Console.WriteLine("First string is greater than second string.");
    }
}