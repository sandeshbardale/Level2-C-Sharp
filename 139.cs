using System;

namespace ExtensionMethodExample
{
    // Step 1: Create a static class
    public static class MyExtensions
    {
        // Step 2: Create an extension method
        // 'this' keyword before first parameter indicates it extends string
        public static int WordCount(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return 0;

            string[] words = str.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }

        // Another example: reverse string
        public static string ReverseString(this string str)
        {
            char[] chars = str.ToCharArray();
            Array.Reverse(chars);
            return new string(chars);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            string sentence = "Hello world from C#";

            // Step 3: Call extension methods like regular methods
            int count = sentence.WordCount();
            Console.WriteLine("Word count: " + count);

            string reversed = sentence.ReverseString();
            Console.WriteLine("Reversed string: " + reversed);
        }
    }
}