using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagementSystem
{
    // Product class to hold product details
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

    class Program
    {
        static List<Product> products = new List<Product>();
        static int nextId = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Inventory Management System ===");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Update Product");
                Console.WriteLine("3. Delete Product");
                Console.WriteLine("4. View All Products");
                Console.WriteLine("5. Search Product");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddProduct();
                        break;
                    case "2":
                        UpdateProduct();
                        break;
                    case "3":
                        DeleteProduct();
                        break;
                    case "4":
                        ViewProducts();
                        break;
                    case "5":
                        SearchProduct();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice! Press Enter to try again.");
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

            products.Add(new Product { Id = nextId++, Name = name, Quantity = quantity, Price = price });
            Console.WriteLine("Product added successfully! Press Enter to continue...");
            Console.ReadLine();
        }

        static void UpdateProduct()
        {
            Console.Write("Enter Product ID to update: ");
            int id = int.Parse(Console.ReadLine());

            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                Console.Write("Enter new name (leave blank to keep current): ");
                string name = Console.ReadLine();
                if (!string.IsNullOrEmpty(name)) product.Name = name;

                Console.Write("Enter new quantity (leave blank to keep current): ");
                string qtyInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(qtyInput)) product.Quantity = int.Parse(qtyInput);

                Console.Write("Enter new price (leave blank to keep current): ");
                string priceInput = Console.ReadLine();
                if (!string.IsNullOrEmpty(priceInput)) product.Price = double.Parse(priceInput);

                Console.WriteLine("Product updated successfully! Press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Product not found! Press Enter to continue...");
            }
            Console.ReadLine();
        }

        static void DeleteProduct()
        {
            Console.Write("Enter Product ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            Product product = products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                products.Remove(product);
                Console.WriteLine("Product deleted successfully! Press Enter to continue...");
            }
            else
            {
                Console.WriteLine("Product not found! Press Enter to continue...");
            }
            Console.ReadLine();
        }

        static void ViewProducts()
        {
            Console.WriteLine("=== All Products ===");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
            }
            else
            {
                foreach (var product in products)
                {
                    Console.WriteLine(product);
                }
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }

        static void SearchProduct()
        {
            Console.Write("Enter product name to search: ");
            string search = Console.ReadLine().ToLower();

            var results = products.Where(p => p.Name.ToLower().Contains(search)).ToList();

            if (results.Count > 0)
            {
                Console.WriteLine("=== Search Results ===");
                foreach (var product in results)
                {
                    Console.WriteLine(product);
                }
            }
            else
            {
                Console.WriteLine("No matching products found.");
            }
            Console.WriteLine("Press Enter to continue...");
            Console.ReadLine();
        }
    }
}