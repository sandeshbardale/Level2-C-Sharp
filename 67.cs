using System;

class RemoveWhiteSpaces
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        // Remove all white spaces
        string result = input.Replace(" ", "");

        Console.WriteLine("String without white spaces: " + result);
    }
}