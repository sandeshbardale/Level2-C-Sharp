using System;
using System.IO;

class FileHandlingExample
{
    static void Main(string[] args)
    {
        string filePath = "example.txt";

        // ----------------------------
        // 1. Write to a file
        // ----------------------------
        string[] lines = { "Hello, World!", "Welcome to C# File Handling", "Line 3" };
        File.WriteAllLines(filePath, lines);  // Creates file if not exists

        Console.WriteLine("File written successfully.");

        // ----------------------------
        // 2. Read from a file
        // ----------------------------
        string[] readLines = File.ReadAllLines(filePath);
        Console.WriteLine("\nReading file content:");
        foreach (var line in readLines)
        {
            Console.WriteLine(line);
        }

        // ----------------------------
        // 3. Append to a file
        // ----------------------------
        File.AppendAllText(filePath, "\nAppended line using File.AppendAllText");
        Console.WriteLine("\nLine appended successfully.");

        // ----------------------------
        // 4. Read updated content
        // ----------------------------
        Console.WriteLine("\nUpdated file content:");
        string updatedContent = File.ReadAllText(filePath);
        Console.WriteLine(updatedContent);

        // ----------------------------
        // 5. Delete the file
        // ----------------------------
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Console.WriteLine("\nFile deleted successfully.");
        }
    }
}