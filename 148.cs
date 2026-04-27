using System;
using System.Reflection;

class Person
{
    public string Name { get; set; }
    private int Age { get; set; }

    public Person() { }

    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public void Greet()
    {
        Console.WriteLine($"Hello, my name is {Name} and I am {Age} years old.");
    }

    private void SecretMethod()
    {
        Console.WriteLine("This is a secret method!");
    }
}

class ReflectionExample
{
    static void Main(string[] args)
    {
        // Step 1: Get type information
        Type personType = typeof(Person);
        Console.WriteLine("Class Name: " + personType.Name);

        // Step 2: List all properties
        Console.WriteLine("\nProperties:");
        foreach (PropertyInfo prop in personType.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine($"- {prop.Name} ({prop.PropertyType.Name})");
        }

        // Step 3: List all methods
        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in personType.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
        {
            Console.WriteLine($"- {method.Name}");
        }

        // Step 4: Create object dynamically
        object personObj = Activator.CreateInstance(personType, "Alice", 25);

        // Step 5: Invoke public method
        MethodInfo greetMethod = personType.GetMethod("Greet");
        greetMethod.Invoke(personObj, null);

        // Step 6: Access private property
        PropertyInfo ageProp = personType.GetProperty("Age", BindingFlags.NonPublic | BindingFlags.Instance);
        ageProp.SetValue(personObj, 30);
        Console.WriteLine("\nUpdated Age via Reflection:");
        greetMethod.Invoke(personObj, null);

        // Step 7: Invoke private method
        MethodInfo secretMethod = personType.GetMethod("SecretMethod", BindingFlags.NonPublic | BindingFlags.Instance);
        secretMethod.Invoke(personObj, null);
    }
}