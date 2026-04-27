using System;

class Calculator
{
    // Method Overloading (Compile-time Polymorphism)
    public int Add(int a, int b)
    {
        return a + b;
    }

    public double Add(double a, double b)
    {
        return a + b;
    }
}

// Base class
class Shape
{
    public virtual void Draw()
    {
        Console.WriteLine("Drawing Shape");
    }
}

// Derived class
class Circle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Compile-time polymorphism
        Calculator calc = new Calculator();
        Console.WriteLine("Sum (int): " + calc.Add(5, 10));
        Console.WriteLine("Sum (double): " + calc.Add(5.5, 2.5));

        // Runtime polymorphism
        Shape s = new Circle();
        s.Draw();

        Console.ReadLine();
    }
}