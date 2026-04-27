using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
    }

    class Course
    {
        public int StudentId { get; set; }
        public string CourseName { get; set; }
    }

    static void Main(string[] args)
    {
        // Student list
        List<Student> students = new List<Student>()
        {
            new Student { StudentId = 1, Name = "Alice" },
            new Student { StudentId = 2, Name = "Bob" },
            new Student { StudentId = 3, Name = "Charlie" }
        };

        // Course list
        List<Course> courses = new List<Course>()
        {
            new Course { StudentId = 1, CourseName = "Math" },
            new Course { StudentId = 2, CourseName = "Science" },
            new Course { StudentId = 3, CourseName = "English" }
        };

        // LINQ Join
        var result = students.Join(
            courses,
            s => s.StudentId,          // Outer key
            c => c.StudentId,          // Inner key
            (s, c) => new              // Result
            {
                s.Name,
                c.CourseName
            });

        Console.WriteLine("Student Course Details:");

        foreach (var item in result)
        {
            Console.WriteLine(item.Name + " - " + item.CourseName);
        }
    }
}