using System;
using System.Collections.Generic;

namespace EmployeePayrollSystem
{
    // Employee class
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double BasicSalary { get; set; }
        public double HRA { get; set; }  // House Rent Allowance
        public double DA { get; set; }   // Dearness Allowance
        public double GrossSalary { get; set; }

        // Method to calculate gross salary
        public void CalculateGrossSalary()
        {
            HRA = 0.1 * BasicSalary;
            DA = 0.2 * BasicSalary;
            GrossSalary = BasicSalary + HRA + DA;
        }

        // Display employee details
        public void Display()
        {
            Console.WriteLine($"ID: {Id}");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Basic Salary: {BasicSalary:C}");
            Console.WriteLine($"HRA: {HRA:C}");
            Console.WriteLine($"DA: {DA:C}");
            Console.WriteLine($"Gross Salary: {GrossSalary:C}");
            Console.WriteLine("----------------------------");
        }
    }

    class Program
    {
        static List<Employee> employees = new List<Employee>();

        static void Main(string[] args)
        {
            int choice;

            do
            {
                Console.WriteLine("=== Employee Payroll System ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. Display All Employees");
                Console.WriteLine("3. Exit");
                Console.Write("Enter your choice: ");
                
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid input! Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        DisplayEmployees();
                        break;
                    case 3:
                        Console.WriteLine("Exiting program...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice! Please try again.");
                        break;
                }

            } while (choice != 3);
        }

        // Method to add employee
        static void AddEmployee()
        {
            Employee emp = new Employee();

            Console.Write("Enter Employee ID: ");
            emp.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Employee Name: ");
            emp.Name = Console.ReadLine();

            Console.Write("Enter Basic Salary: ");
            emp.BasicSalary = double.Parse(Console.ReadLine());

            emp.CalculateGrossSalary();
            employees.Add(emp);

            Console.WriteLine("Employee added successfully!\n");
        }

        // Method to display all employees
        static void DisplayEmployees()
        {
            if (employees.Count == 0)
            {
                Console.WriteLine("No employees found.\n");
                return;
            }

            Console.WriteLine("\n=== Employee Details ===");
            foreach (var emp in employees)
            {
                emp.Display();
            }
        }
    }
}