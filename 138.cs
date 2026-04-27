using System;

class AnonymousMethodExample
{
    // Step 1: Declare a delegate
    delegate int MathOperation(int a, int b);

    static void Main(string[] args)
    {
        // Step 2: Using anonymous method
        MathOperation add = delegate (int x, int y)
        {
            return x + y;
        };

        MathOperation multiply = delegate (int x, int y)
        {
            return x * y;
        };

        // Step 3: Invoke anonymous methods
        Console.WriteLine("Addition using anonymous method: " + add(5, 10));
        Console.WriteLine("Multiplication using anonymous method: " + multiply(5, 10));

        // Step 4: Using anonymous method with Action delegate
        Action<string> greet = delegate (string name)
        {
            Console.WriteLine("Hello, " + name + "!");
        };

        greet("Alice");
    }
}