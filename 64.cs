using System;

class PalindromeCheck
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        string reversed = "";

        // Reverse the string
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }

        // Check if original string equals reversed string
        if (input.Equals(reversed, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine("The string is a palindrome.");
        }
        else
        {
            Console.WriteLine("The string is not a palindrome.");
        }
    }
}