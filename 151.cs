using System;
using System.Collections.Generic;
using System.Linq;

class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}

class StudentManagementSystem
{
    private List<Student> students = new List<Student>();
    private int nextId = 1;

    public void AddStudent()
    {
        Console.Write("Enter Student Name: ");
        string name = Console.ReadLine();
        Console.Write("Enter Age: ");
        int age = int.Parse(Console.ReadLine());

        Student student = new Student
        {
            Id = nextId++,
            Name = name,
            Age = age
        };
        students.Add(student);

        Console.WriteLine("Student added successfully!\n");
    }

    public void ViewStudents()
    {
        if (students.Count == 0)
        {
            Console.WriteLine("No students found.\n");
            return;
        }

        Console.WriteLine("\nList of Students:");
        foreach (var s in students)
        {
            Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
        }
        Console.WriteLine();
    }

    public void UpdateStudent()
    {
        Console.Write("Enter Student ID to update: ");
        int id = int.Parse(Console.ReadLine());

        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            Console.WriteLine("Student not found!\n");
            return;
        }

        Console.Write("Enter new name (leave blank to keep current): ");
        string name = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(name))
            student.Name = name;

        Console.Write("Enter new age (leave blank to keep current): ");
        string ageInput = Console.ReadLine();
        if (int.TryParse(ageInput, out int age))
            student.Age = age;

        Console.WriteLine("Student updated successfully!\n");
    }

    public void DeleteStudent()
    {
        Console.Write("Enter Student ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        var student = students.FirstOrDefault(s => s.Id == id);
        if (student == null)
        {
            Console.WriteLine("Student not found!\n");
            return;
        }

        students.Remove(student);
        Console.WriteLine("Student deleted successfully!\n");
    }
}

class Program
{
    static void Main()
    {
        StudentManagementSystem sms = new StudentManagementSystem();
        int choice;

        do
        {
            Console.WriteLine("=== Student Management System ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. View Students");
            Console.WriteLine("3. Update Student");
            Console.WriteLine("4. Delete Student");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: sms.AddStudent(); break;
                case 2: sms.ViewStudents(); break;
                case 3: sms.UpdateStudent(); break;
                case 4: sms.DeleteStudent(); break;
                case 5: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice!\n"); break;
            }
        } while (choice != 5);
    }
}