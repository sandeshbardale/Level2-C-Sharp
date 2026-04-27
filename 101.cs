using System;

class Student
{
    // Data members (fields)
    public string name;
    public int age;

    // Method to display student details
    public void Display()
    {
        Console.WriteLine("Student Name: " + name);
        Console.WriteLine("Student Age: " + age);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating object of class Student
        Student s1 = new Student();

        // Assigning values
        s1.name = "Payal";
        s1.age = 20;

        // Calling method
        s1.Display();

        Console.ReadLine();
    }
}