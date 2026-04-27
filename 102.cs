using System;

class Student
{
    // Data members
    int id;
    string name;

    // Default Constructor
    public Student()
    {
        id = 0;
        name = "Unknown";
    }

    // Parameterized Constructor
    public Student(int i, string n)
    {
        id = i;
        name = n;
    }

    // Method to display data
    public void Display()
    {
        Console.WriteLine("Student ID: " + id);
        Console.WriteLine("Student Name: " + name);
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Using default constructor
        Student s1 = new Student();
        s1.Display();

        // Using parameterized constructor
        Student s2 = new Student(101, "Payal");
        s2.Display();

        Console.ReadLine();
    }
}