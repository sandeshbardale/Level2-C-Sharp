using System;

// Base class
class Animal
{
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Derived class
class Dog : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Base class reference, derived class object
        Animal a = new Dog();

        // Calls overridden method
        a.Sound();

        Console.ReadLine();
    }
}