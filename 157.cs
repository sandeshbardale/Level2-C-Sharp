using System;
using System.Data;
using System.Data.SqlClient;

namespace AdoNetCRUD
{
    class Program
    {
        // Replace with your SQL Server connection string
        static string connectionString = @"Server=.\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== ADO.NET CRUD Application ===");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View All Students");
                Console.WriteLine("3. Update Student");
                Console.WriteLine("4. Delete Student");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudent();
                        break;
                    case "2":
                        ViewStudents();
                        break;
                    case "3":
                        UpdateStudent();
                        break;
                    case "4":
                        DeleteStudent();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to try again.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter Course: ");
            string course = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Students (Name, Age, Course) VALUES (@Name, @Age, @Course)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Course", course);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine($"{rows} student added successfully! Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void ViewStudents()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Students";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("=== All Students ===");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Age: {reader["Age"]}, Course: {reader["Course"]}");
                }

                reader.Close();
                conn.Close();
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void UpdateStudent()
        {
            Console.Write("Enter Student ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter new Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new Age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter new Course: ");
            string course = Console.ReadLine();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE Students SET Name=@Name, Age=@Age, Course=@Course WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Course", course);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine($"{rows} student updated successfully! Press Enter to continue...");
                Console.ReadLine();
            }
        }

        static void DeleteStudent()
        {
            Console.Write("Enter Student ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Students WHERE Id=@Id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                conn.Close();

                Console.WriteLine($"{rows} student deleted successfully! Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }
}