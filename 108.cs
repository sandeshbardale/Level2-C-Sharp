using System;

// Interface
interface IShape
{
    void Draw(); // method without body
}

// Class implementing interface
class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

// Another class implementing interface
class Rectangle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Rectangle");
    }
}

class Program
{
    static void Main(string[] args)
    {
        IShape s;

        s = new Circle();
        s.Draw();

        s = new Rectangle();
        s.Draw();

        Console.ReadLine();
    }
}