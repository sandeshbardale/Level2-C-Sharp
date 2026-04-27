using System;

// Base class
class Animal
{
    // Virtual method in base class
    public virtual void Sound()
    {
        Console.WriteLine("Animal makes a sound");
    }
}

// Derived class
class Dog : Animal
{
    // Overriding the virtual method
    public override void Sound()
    {
        Console.WriteLine("Dog barks");
    }
}

// Another derived class
class Cat : Animal
{
    public override void Sound()
    {
        Console.WriteLine("Cat meows");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Animal a1 = new Dog();   // Base class reference, derived class object
        Animal a2 = new Cat();

        a1.Sound();  // Calls Dog's overridden method
        a2.Sound();  // Calls Cat's overridden method

        Console.ReadLine();
    }
}