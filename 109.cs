using System;

// First Interface
interface IStudent
{
    void GetStudent();
}

// Second Interface
interface IMarks
{
    void GetMarks();
}

// Class implementing multiple interfaces
class Result : IStudent, IMarks
{
    int id, marks;

    public void GetStudent()
    {
        id = 101;
        Console.WriteLine("Student ID: " + id);
    }

    public void GetMarks()
    {
        marks = 85;
        Console.WriteLine("Marks: " + marks);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Result r = new Result();

        r.GetStudent();
        r.GetMarks();

        Console.ReadLine();
    }
}