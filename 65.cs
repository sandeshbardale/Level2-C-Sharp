using System;

class WordCount
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            Console.WriteLine("Number of words: 0");
        }
        else
        {
            // Split the string by spaces and count the words
            string[] words = input.Split(new char[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            Console.WriteLine("Number of words: " + words.Length);
        }
    }
}