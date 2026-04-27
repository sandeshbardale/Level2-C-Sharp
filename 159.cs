using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniERP
{
    // Product class
    class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Quantity: {Quantity}, Price: {Price:C}";
        }
    }

    // Employee class
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Position: {Position}";
        }
    }

    // Sale class
    class Sale
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }

        public override string ToString()
        {
            return $"Sale ID: {Id}, Product ID: {ProductId}, Quantity: {Quantity}, Total: {TotalAmount:C}";
        }
    }

    class Program
    {
        static List<Product> products = new List<Product>();
        static List<Employee> employees = new List<Employee>();
        static List<Sale> sales = new List<Sale>();

        static int nextProductId = 1;
        static int nextEmployeeId = 1;
        static int nextSaleId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Mini ERP System ===");
                Console.WriteLine("1. Product Management");
                Console.WriteLine("2. Employee Management");
                Console.WriteLine("3. Sales Management");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ProductMenu();
                        break;
                    case "2":
                        EmployeeMenu();
                        break;
                    case "3":
                        SalesMenu();
                        break;
                    case "4":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        // Product Management
        static void ProductMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Product Management ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. View Products");
                Console.WriteLine("3. Update Product");
                Console.WriteLine("4. Delete Product");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddProduct(); break;
                    case "2": ViewProducts(); break;
                    case "3": UpdateProduct(); break;
                    case "4": DeleteProduct(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddProduct()
        {
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter quantity: ");
            int quantity = int.Parse(Console.ReadLine());
            Console.Write("Enter price: ");
            double price = double.Parse(Console.ReadLine());

            products.Add(new Product { Id = nextProductId++, Name = name, Quantity = quantity, Price = price });
            Console.WriteLine("Product added successfully! Press Enter...");
            Console.ReadLine();
        }

        static void ViewProducts()
        {
            Console.WriteLine("=== All Products ===");
            if (products.Count == 0) Console.WriteLine("No products found.");
            else products.ForEach(p => Console.WriteLine(p));
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Console.Write("New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) product.Name = name;

                Console.Write("New Quantity (leave blank to keep current): ");
                string qty = Console.ReadLine();
                if (!string.IsNullOrEmpty(qty)) product.Quantity = int.Parse(qty);

                Console.Write("New Price (leave blank to keep current): ");
                string price = Console.ReadLine();
                if (!string.IsNullOrEmpty(price)) product.Price = double.Parse(price);

                Console.WriteLine("Product updated successfully! Press Enter...");
            }
            else
            {
                Console.WriteLine("Product not found! Press Enter...");
            }
            Console.ReadLine();
        }

        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully! Press Enter...");
            }
            else
            {
                Console.WriteLine("Product not found! Press Enter...");
            }
            Console.ReadLine();
        }

        // Employee Management
        static void EmployeeMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Employee Management ===");
                Console.WriteLine("1. Add Employee");
                Console.WriteLine("2. View Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddEmployee(); break;
                    case "2": ViewEmployees(); break;
                    case "3": UpdateEmployee(); break;
                    case "4": DeleteEmployee(); break;
                    case "5": return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddEmployee()
        {
            Console.Write("Enter employee name: ");
            string name = Console.ReadLine();
            Console.Write("Enter position: ");
            string position = Console.ReadLine();

            employees.Add(new Employee { Id = nextEmployeeId++, Name = name, Position = position });
            Console.WriteLine("Employee added successfully! Press Enter...");
            Console.ReadLine();
        }

        static void ViewEmployees()
        {
            Console.WriteLine("=== All Employees ===");
            if (employees.Count == 0) Console.WriteLine("No employees found.");
            else employees.ForEach(e => Console.WriteLine(e));
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void UpdateEmployee()
        {
            Console.Write("Enter Employee ID to update: ");
            int id = int.Parse(Console.ReadLine());
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                Console.Write("New Name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) emp.Name = name;

                Console.Write("New Position (leave blank to keep current): ");
                string pos = Console.ReadLine();
                if (!string.IsNullOrEmpty(pos)) emp.Position = pos;

                Console.WriteLine("Employee updated successfully! Press Enter...");
            }
            else
            {
                Console.WriteLine("Employee not found! Press Enter...");
            }
            Console.ReadLine();
        }

        static void DeleteEmployee()
        {
            Console.Write("Enter Employee ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            var emp = employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                employees.Remove(emp);
                Console.WriteLine("Employee deleted successfully! Press Enter...");
            }
            else
            {
                Console.WriteLine("Employee not found! Press Enter...");
            }
            Console.ReadLine();
        }

        // Sales Management
        static void SalesMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Sales Management ===");
                Console.WriteLine("1. Add Sale");
                Console.WriteLine("2. View Sales");
                Console.WriteLine("3. Back to Main Menu");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1": AddSale(); break;
                    case "2": ViewSales(); break;
                    case "3": return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to continue...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void AddSale()
        {
            Console.Write("Enter Product ID: ");
            int pid = int.Parse(Console.ReadLine());
            var product = products.FirstOrDefault(p => p.Id == pid);
            if (product == null)
            {
                Console.WriteLine("Product not found! Press Enter...");
                Console.ReadLine();
                return;
            }

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());
            if (qty > product.Quantity)
            {
                Console.WriteLine("Insufficient stock! Press Enter...");
                Console.ReadLine();
                return;
            }

            double total = qty * product.Price;
            product.Quantity -= qty;

            sales.Add(new Sale { Id = nextSaleId++, ProductId = pid, Quantity = qty, TotalAmount = total });
            Console.WriteLine($"Sale recorded! Total Amount: {total:C}. Press Enter...");
            Console.ReadLine();
        }

        static void ViewSales()
        {
            Console.WriteLine("=== All Sales ===");
            if (sales.Count == 0) Console.WriteLine("No sales recorded.");
            else sales.ForEach(s => Console.WriteLine(s));
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}