using System;

class Demo
{
    // Constant - value must be assigned at declaration and cannot change
    public const double PI = 3.14159;

    // Readonly - value can be assigned at declaration or in constructor
    public readonly int id;

    // Constructor
    public Demo(int value)
    {
        id = value; // Allowed for readonly
    }

    public void Display()
    {
        Console.WriteLine("Const PI: " + PI);
        Console.WriteLine("Readonly ID: " + id);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Demo obj = new Demo(101);
        obj.Display();

        // Uncommenting the following lines will cause errors
        // Demo.PI = 3.14;   // Error: cannot modify const
        // obj.id = 102;      // Error: cannot modify readonly outside constructor

        Console.ReadLine();
    }
}