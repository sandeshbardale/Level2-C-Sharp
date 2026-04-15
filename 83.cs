using System;

class Program
{
    static void Main(string[] args)
    {
        string text = "C sharp programming language";

        // Splitting string into words
        string[] words = text.Split(' ');

        Console.WriteLine("Words in the string:");

        foreach (string word in words)
        {
            Console.WriteLine(word);
        }

        Console.ReadLine();
    }
}