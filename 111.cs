using System;

// Base class
class Person
{
    // Fields with different access specifiers
    public string name;       // accessible everywhere
    private int age;          // accessible only within the class
    protected string city;    // accessible within class and derived classes
    internal string country;  // accessible within same assembly

    // Public method to set private field
    public void SetAge(int a)
    {
        age = a;
    }

    // Public method to get private field
    public int GetAge()
    {
        return age;
    }
}

// Derived class
class Employee : Person
{
    public void DisplayEmployee()
    {
        Console.WriteLine("Name: " + name);      // public
        Console.WriteLine("City: " + city);      // protected
        Console.WriteLine("Country: " + country);// internal
        // Console.WriteLine("Age: " + age);    // private -> not accessible
        Console.WriteLine("Age: " + GetAge());   // Access via public method
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp = new Employee();

        // Access public and internal members
        emp.name = "Payal";
        emp.city = "Pune";       // protected not accessible directly, only inside derived class
        emp.country = "India";

        emp.SetAge(25);          // set private field via public method

        emp.DisplayEmployee();

        Console.ReadLine();
    }
}