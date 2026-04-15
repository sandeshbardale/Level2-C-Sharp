using System;

class Program
{
    // Method with optional parameters
    static void DisplayDetails(string name, int age = 18, string city = "Pune")
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("City: " + city);
        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        // Calling method with only required parameter
        DisplayDetails("Payal");

        // Calling method with two parameters
        DisplayDetails("Riya", 20);

        // Calling method with all parameters
        DisplayDetails("Amit", 25, "Mumbai");

        Console.ReadLine();
    }
}