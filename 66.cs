using System;
using System.Collections.Generic;

class CharacterFrequency
{
    static void Main()
    {
        Console.Write("Enter a string: ");
        string input = Console.ReadLine();

        Dictionary<char, int> frequency = new Dictionary<char, int>();

        foreach (char ch in input)
        {
            if (frequency.ContainsKey(ch))
            {
                frequency[ch]++;
            }
            else
            {
                frequency[ch] = 1;
            }
        }

        Console.WriteLine("Character frequencies:");
        foreach (var pair in frequency)
        {
            Console.WriteLine("'" + pair.Key + "' : " + pair.Value);
        }
    }
}