using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FileBasedCRUD
{
    // Class representing a record
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Age: {Age}, Course: {Course}";
        }
    }

    class Program
    {
        static string filePath = "students.json";
        static List<Student> students = new List<Student>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            LoadData();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== File-based CRUD Application ===");
                Console.WriteLine("1. Create Student");
                Console.WriteLine("2. Read All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateStudent();
                        break;
                    case "2":
                        ReadStudents();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        SaveData();
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Load data from JSON file
        static void LoadData()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
                if (students.Count > 0)
                    nextId = students.Max(s => s.Id) + 1;
            }
        }

        // Save data to JSON file
        static void SaveData()
        {
            string json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        static void CreateStudent()
        {
            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter course: ");
            string course = Console.ReadLine();

            students.Add(new Student { Id = nextId++, Name = name, Age = age, Course = course });
            SaveData();

            Console.WriteLine("Student added successfully! Press Enter to continue...");
            Console.ReadLine();
        }

        static void ReadStudents()
        {
            Console.WriteLine("=== All Students ===");
            if (students.Count == 0)
            {
                Console.WriteLine("No students available.");
            }
            else
            {
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                Console.Write("Enter new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) student.Name = name;

                Console.Write("Enter new age (leave blank to keep current): ");
                string ageInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(ageInput)) student.Age = int.Parse(ageInput);

                Console.Write("Enter new course (leave blank to keep current): ");
                string course = Console.ReadLine();
                if (!string.IsNullOrEmpty(course)) student.Course = course;

                SaveData();
                Console.WriteLine("Student updated successfully! Press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Student not found! Press Enter to continue...");
            }
            Console.ReadLine();
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            var student = students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                SaveData();
                Console.WriteLine("Student deleted successfully! Press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Student not found! Press Enter to continue...");
            }
            Console.ReadLine();
        }
    }
}