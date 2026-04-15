using System;

class RemoveSpecialCharacters
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string result = "";

        foreach (char c in input)
        {
            // Keep only letters and digits
            if (char.IsLetterOrDigit(c))
            {
                result += c;
            }
        }

        Console.WriteLine("String after removing special characters: " + result);
    }
}