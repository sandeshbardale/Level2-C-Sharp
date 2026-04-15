using System;

class MethodDemo
{
    // Method with parameters
    static void Greet(string name)
    {
        Console.WriteLine("Hello, " + name + "!");
    }

    // Method with multiple parameters
    static int AddNumbers(int a, int b)
    {
        return a + b;
    }

    static void Main()
    {
        // Calling method with a single parameter
        Console.Write("Enter your name: ");
        string userName = Console.ReadLine();
        Greet(userName);

        // Calling method with multiple parameters
        Console.Write("Enter first number: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        int num2 = int.Parse(Console.ReadLine());

        int sum = AddNumbers(num1, num2);
        Console.WriteLine("Sum of numbers: " + sum);
    }
}