using System;
using System.Text.RegularExpressions;

class RegexDemo
{
    static void Main()
    {
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine();

        // 1. Check if the string contains only letters
        string patternLetters = @"^[A-Za-z]+$";
        if (Regex.IsMatch(input, patternLetters))
        {
            Console.WriteLine("The string contains only letters.");
        }
        else
        {
            Console.WriteLine("The string contains characters other than letters.");
        }

        // 2. Check if the string contains a valid email
        string patternEmail = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (Regex.IsMatch(input, patternEmail))
        {
            Console.WriteLine("The string is a valid email.");
        }

        // 3. Replace all digits with '*'
        string replaced = Regex.Replace(input, @"\d", "*");
        Console.WriteLine("After replacing digits with '*': " + replaced);

        // 4. Find all words starting with a capital letter
        MatchCollection matches = Regex.Matches(input, @"\b[A-Z][a-z]*\b");
        Console.WriteLine("Words starting with a capital letter:");
        foreach (Match match in matches)
        {
            Console.WriteLine(match.Value);
        }
    }
}