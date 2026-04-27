using System;

class Student
{
    // Private fields
    private int id;
    private string name;

    // Public properties to access private fields
    public int ID
    {
        get { return id; }
        set { id = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Method to display student details
    public void Display()
    {
        Console.WriteLine("Student ID: " + id);
        Console.WriteLine("Student Name: " + name);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student s = new Student();

        // Using properties to set values
        s.ID = 101;
        s.Name = "Payal";

        // Display student details
        s.Display();

        Console.ReadLine();
    }
}