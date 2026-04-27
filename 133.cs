using System;

class DelegateExample
{
    // Step 1: Declare a delegate
    delegate int MathOperation(int a, int b);

    // Step 2: Methods matching delegate signature
    static int Add(int x, int y)
    {
        return x + y;
    }

    static int Multiply(int x, int y)
    {
        return x * y;
    }

    static void Main(string[] args)
    {
        // Step 3: Create delegate instances
        MathOperation op1 = Add;
        MathOperation op2 = Multiply;

        // Step 4: Invoke delegates
        Console.WriteLine("Addition: " + op1(5, 10));
        Console.WriteLine("Multiplication: " + op2(5, 10));

        // Step 5: Using delegate with lambda expression
        MathOperation op3 = (a, b) => a - b;
        Console.WriteLine("Subtraction (lambda): " + op3(20, 8));
    }
}