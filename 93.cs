using System;

class StringFormattingDemo
{
    static void Main()
    {
        string name = "Payal";
        int age = 22;
        double salary = 45000.75;

        // 1. Using concatenation
        Console.WriteLine("Using Concatenation: " + name + " is " + age + " years old and earns " + salary);

        // 2. Using composite formatting
        Console.WriteLine("Using Composite Formatting: {0} is {1} years old and earns {2}", name, age, salary);

        // 3. Using string interpolation (C# 6.0+)
        Console.WriteLine($"Using Interpolation: {name} is {age} years old and earns {salary}");

        // 4. Formatting numbers
        Console.WriteLine("Salary with 2 decimal places: {0:F2}", salary);

        // 5. Padding and alignment
        Console.WriteLine("{0,-10} {1,5} {2,12:F2}", "Name", "Age", "Salary");
        Console.WriteLine("{0,-10} {1,5} {2,12:F2}", name, age, salary);
    }
}