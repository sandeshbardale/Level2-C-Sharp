using System;

class StringImmutabilityDemo
{
    static void Main()
    {
        string str1 = "Hello";
        Console.WriteLine("Original string: " + str1);

        // Modify string using concatenation
        string str2 = str1 + " World";

        Console.WriteLine("After concatenation:");
        Console.WriteLine("str1: " + str1); // Original string unchanged
        Console.WriteLine("str2: " + str2); // New string created

        // Modify string using Replace
        string str3 = str1.Replace('H', 'J');
        Console.WriteLine("\nAfter Replace:");
        Console.WriteLine("str1: " + str1); // Original string unchanged
        Console.WriteLine("str3: " + str3); // New string created

        // Compare references
        Console.WriteLine("\nReference check:");
        Console.WriteLine("str1 and str2 refer to same object? " + Object.ReferenceEquals(str1, str2));
        Console.WriteLine("str1 and str3 refer to same object? " + Object.ReferenceEquals(str1, str3));
    }
}