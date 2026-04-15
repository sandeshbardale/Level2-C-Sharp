using System;

class StringCaseConversion
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Convert to uppercase
        string upperCase = input.ToUpper();

        // Convert to lowercase
        string lowerCase = input.ToLower();

        Console.WriteLine("Uppercase: " + upperCase);
        Console.WriteLine("Lowercase: " + lowerCase);
    }
}