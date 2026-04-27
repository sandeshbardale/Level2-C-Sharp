using System;

// Abstract class
abstract class Shape
{
    // Abstract method (no body)
    public abstract void Draw();
}

// Derived class
class Circle : Shape
{
    // Implementation of abstract method
    public override void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

// Another derived class
class Rectangle : Shape
{
    public override void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Abstract class reference
        Shape s;

        s = new Circle();
        s.Draw();

        s = new Rectangle();
        s.Draw();

        Console.ReadLine();
    }
}