using System;

class Program
{
    // Method with parameters
    static void DisplayDetails(string name, int age, string city)
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("City: " + city);
    }

    static void Main(string[] args)
    {
        // Calling method using named arguments
        DisplayDetails(name: "Payal", age: 20, city: "Pune");

        Console.WriteLine();

        // Changing the order of arguments using names
        DisplayDetails(city: "Mumbai", name: "Riya", age: 22);

        Console.ReadLine();
    }
}