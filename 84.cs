using System;

class AnagramCheck
{
    static void Main()
    {
        Console.Write("Enter first string: ");
        string str1 = Console.ReadLine();

        Console.Write("Enter second string: ");
        string str2 = Console.ReadLine();

        // Convert to lowercase
        str1 = str1.ToLower();
        str2 = str2.ToLower();

        // Convert strings to character array
        char[] arr1 = str1.ToCharArray();
        char[] arr2 = str2.ToCharArray();

        // Sort arrays
        Array.Sort(arr1);
        Array.Sort(arr2);

        // Convert arrays back to string
        string sorted1 = new string(arr1);
        string sorted2 = new string(arr2);

        // Compare
        if (sorted1 == sorted2)
        {
            Console.WriteLine("Strings are Anagrams.");
        }
        else
        {
            Console.WriteLine("Strings are NOT Anagrams.");
        }
    }
}