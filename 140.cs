using System;
using System.Collections.Generic;

// Step 1: Create a generic class
class GenericClass<T>
{
    private T data;

    public void SetData(T value)
    {
        data = value;
    }

    public T GetData()
    {
        return data;
    }
}

// Step 2: Generic method example
class Utility
{
    public static void Display<T>(T value)
    {
        Console.WriteLine("Value: " + value);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Using generic class with int
        GenericClass<int> intObj = new GenericClass<int>();
        intObj.SetData(100);
        Console.WriteLine("GenericClass<int> data: " + intObj.GetData());

        // Using generic class with string
        GenericClass<string> strObj = new GenericClass<string>();
        strObj.SetData("Hello Generics");
        Console.WriteLine("GenericClass<string> data: " + strObj.GetData());

        // Using generic method
        Utility.Display<int>(50);
        Utility.Display<string>("Generic Method Example");

        // Using generic collection: List<T>
        List<double> numbers = new List<double>() { 1.1, 2.2, 3.3 };
        Console.WriteLine("\nGeneric List elements:");
        foreach (var num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}