using System;
using System.Text.RegularExpressions;

class PasswordValidator
{
    static void Main()
    {
        Console.Write("Enter a password: ");
        string password = Console.ReadLine();

        if (IsStrongPassword(password))
        {
            Console.WriteLine("Strong Password.");
        }
        else
        {
            Console.WriteLine("Weak Password. Password must contain:");
            Console.WriteLine("- At least 8 characters");
            Console.WriteLine("- At least one uppercase letter");
            Console.WriteLine("- At least one lowercase letter");
            Console.WriteLine("- At least one digit");
            Console.WriteLine("- At least one special character (!,@,#,$, etc.)");
        }
    }

    static bool IsStrongPassword(string password)
    {
        // Pattern explanation:
        // ^                 -> start of string
        // (?=.*[a-z])       -> at least one lowercase
        // (?=.*[A-Z])       -> at least one uppercase
        // (?=.*\d)          -> at least one digit
        // (?=.*[@$!%*?&])   -> at least one special character
        // .{8,}             -> minimum 8 characters
        // $                 -> end of string
        string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$";

        return Regex.IsMatch(password, pattern);
    }
}