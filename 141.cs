using System;

// Step 1: Generic class with constraints
// T must be a class and must have a parameterless constructor
class GenericClass<T> where T : class, new()
{
    public T CreateInstance()
    {
        // Can create instance because of 'new()' constraint
        return new T();
    }

    public void DisplayType(T obj)
    {
        Console.WriteLine("Type of T: " + obj.GetType().Name);
    }
}

// Step 2: A sample class
class Person
{
    public string Name { get; set; } = "Default Person";
}

class Program
{
    static void Main(string[] args)
    {
        // Using generic class with constraint
        GenericClass<Person> obj = new GenericClass<Person>();

        Person p = obj.CreateInstance();
        obj.DisplayType(p);

        Console.WriteLine("Person Name: " + p.Name);
    }
}