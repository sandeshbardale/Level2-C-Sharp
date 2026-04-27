using System;
using System.Collections.Generic;
using System.Linq;

namespace RoleBasedAuthSystem
{
    // User class
    class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // e.g., Admin, Manager, Employee
    }

    class Program
    {
        static List<User> users = new List<User>
        {
            new User { Username = "admin", Password = "admin123", Role = "Admin" },
            new User { Username = "manager", Password = "manager123", Role = "Manager" },
            new User { Username = "employee", Password = "employee123", Role = "Employee" }
        };

        static void Main(string[] args)
        {
            Console.WriteLine("=== Role-Based Authentication System ===");

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter Password: ");
            string password = Console.ReadLine();

            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                Console.WriteLine($"\nLogin successful! Welcome {user.Username} ({user.Role})\n");
                ShowMenu(user);
            }
            else
            {
                Console.WriteLine("\nInvalid credentials! Access denied.");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        static void ShowMenu(User user)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== Main Menu ===");

                if (user.Role == "Admin")
                {
                    Console.WriteLine("1. Manage Users");
                    Console.WriteLine("2. View Reports");
                    Console.WriteLine("3. Exit");
                }
                else if (user.Role == "Manager")
                {
                    Console.WriteLine("1. View Reports");
                    Console.WriteLine("2. Exit");
                }
                else if (user.Role == "Employee")
                {
                    Console.WriteLine("1. View Tasks");
                    Console.WriteLine("2. Exit");
                }

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (user.Role)
                {
                    case "Admin":
                        switch (choice)
                        {
                            case "1": ManageUsers(); break;
                            case "2": ViewReports(); break;
                            case "3": exit = true; break;
                            default: Console.WriteLine("Invalid choice!"); break;
                        }
                        break;

                    case "Manager":
                        switch (choice)
                        {
                            case "1": ViewReports(); break;
                            case "2": exit = true; break;
                            default: Console.WriteLine("Invalid choice!"); break;
                        }
                        break;

                    case "Employee":
                        switch (choice)
                        {
                            case "1": ViewTasks(); break;
                            case "2": exit = true; break;
                            default: Console.WriteLine("Invalid choice!"); break;
                        }
                        break;
                }

                Console.WriteLine();
            }
        }

        static void ManageUsers()
        {
            Console.WriteLine("\n=== User Management ===");
            foreach (var u in users)
            {
                Console.WriteLine($"Username: {u.Username}, Role: {u.Role}");
            }
            Console.WriteLine();
        }

        static void ViewReports()
        {
            Console.WriteLine("\n=== Reports ===");
            Console.WriteLine("Displaying reports for your role...");
        }

        static void ViewTasks()
        {
            Console.WriteLine("\n=== Tasks ===");
            Console.WriteLine("Displaying assigned tasks for Employee...");
        }
    }
}