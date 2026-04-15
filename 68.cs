using System;

class ReplaceSubstring
{
    static void Main()
    {
        Console.Write("Enter the original string: ");
        string original = Console.ReadLine();

        Console.Write("Enter the substring to replace: ");
        string oldSubstring = Console.ReadLine();

        Console.Write("Enter the new substring: ");
        string newSubstring = Console.ReadLine();

        // Replace the substring
        string result = original.Replace(oldSubstring, newSubstring);

        Console.WriteLine("Updated string: " + result);
    }
}