using System;

// Base class
class Person
{
    public string name;

    public void DisplayPerson()
    {
        Console.WriteLine("Name: " + name);
    }
}

// Derived class
class Student : Person
{
    public int rollNo;

    public void DisplayStudent()
    {
        Console.WriteLine("Roll No: " + rollNo);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating object of derived class
        Student s = new Student();

        // Accessing base class member
        s.name = "Payal";

        // Accessing derived class member
        s.rollNo = 101;

        // Calling methods
        s.DisplayPerson();
        s.DisplayStudent();

        Console.ReadLine();
    }
}