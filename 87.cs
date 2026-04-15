using System;
using System.Text.RegularExpressions;

class EmailValidator
{
    static void Main()
    {
        Console.Write("Enter an email address: ");
        string email = Console.ReadLine();

        // Regular expression pattern for email
        string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";

        // Validate email
        if (Regex.IsMatch(email, pattern))
        {
            Console.WriteLine("Valid Email Address.");
        }
        else
        {
            Console.WriteLine("Invalid Email Address.");
        }
    }
}