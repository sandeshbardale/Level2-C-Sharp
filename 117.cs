using System;

// Abstract Class
abstract class Vehicle
{
    public abstract void Start(); // Abstract method
    public void Stop()             // Regular method
    {
        Console.WriteLine("Vehicle stopped");
    }
}

// Interface
interface IFlyable
{
    void Fly();  // Only abstract methods allowed
}

// Derived class implementing abstract class and interface
class Airplane : Vehicle, IFlyable
{
    public override void Start()
    {
        Console.WriteLine("Airplane started");
    }

    public void Fly()
    {
        Console.WriteLine("Airplane is flying");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Airplane plane = new Airplane();

        plane.Start();  // From abstract class
        plane.Fly();    // From interface
        plane.Stop();   // Regular method from abstract class

        Console.ReadLine();
    }
}