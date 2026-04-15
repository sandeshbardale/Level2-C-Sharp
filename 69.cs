using System;
using System.Text;

class StringBuilderDemo
{
    static void Main()
    {
        // Create a new StringBuilder instance
        StringBuilder sb = new StringBuilder("Hello");

        // Append text
        sb.Append(" World");
        Console.WriteLine("After Append: " + sb);

        // Insert text at a specific position
        sb.Insert(6, "C# ");
        Console.WriteLine("After Insert: " + sb);

        // Replace text
        sb.Replace("World", "Universe");
        Console.WriteLine("After Replace: " + sb);

        // Remove text
        sb.Remove(6, 3); // Removes "C# "
        Console.WriteLine("After Remove: " + sb);

        // Display the length of the StringBuilder
        Console.WriteLine("Length: " + sb.Length);
    }
}