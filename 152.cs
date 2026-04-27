using System;
using System.Collections.Generic;
using System.Linq;

// Book class
class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public bool IsIssued { get; set; } = false;
}

// Library Management System class
class LibraryManagementSystem
{
    private List<Book> books = new List<Book>();
    private int nextBookId = 1;

    // Add a new book
    public void AddBook()
    {
        Console.Write("Enter Book Title: ");
        string title = Console.ReadLine();
        Console.Write("Enter Author Name: ");
        string author = Console.ReadLine();

        Book book = new Book
        {
            Id = nextBookId++,
            Title = title,
            Author = author
        };
        books.Add(book);
        Console.WriteLine("Book added successfully!\n");
    }

    // View all books
    public void ViewBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.\n");
            return;
        }

        Console.WriteLine("\nList of Books:");
        foreach (var b in books)
        {
            string status = b.IsIssued ? "Issued" : "Available";
            Console.WriteLine($"ID: {b.Id}, Title: {b.Title}, Author: {b.Author}, Status: {status}");
        }
        Console.WriteLine();
    }

    // Issue a book
    public void IssueBook()
    {
        Console.Write("Enter Book ID to issue: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Book not found!\n");
            return;
        }
        if (book.IsIssued)
        {
            Console.WriteLine("Book is already issued!\n");
            return;
        }

        book.IsIssued = true;
        Console.WriteLine($"Book '{book.Title}' issued successfully!\n");
    }

    // Return a book
    public void ReturnBook()
    {
        Console.Write("Enter Book ID to return: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Book not found!\n");
            return;
        }
        if (!book.IsIssued)
        {
            Console.WriteLine("Book was not issued!\n");
            return;
        }

        book.IsIssued = false;
        Console.WriteLine($"Book '{book.Title}' returned successfully!\n");
    }

    // Delete a book
    public void DeleteBook()
    {
        Console.Write("Enter Book ID to delete: ");
        int id = int.Parse(Console.ReadLine());

        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Book not found!\n");
            return;
        }

        books.Remove(book);
        Console.WriteLine($"Book '{book.Title}' deleted successfully!\n");
    }
}

// Main program
class Program
{
    static void Main()
    {
        LibraryManagementSystem library = new LibraryManagementSystem();
        int choice;

        do
        {
            Console.WriteLine("=== Library Management System ===");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View Books");
            Console.WriteLine("3. Issue Book");
            Console.WriteLine("4. Return Book");
            Console.WriteLine("5. Delete Book");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: library.AddBook(); break;
                case 2: library.ViewBooks(); break;
                case 3: library.IssueBook(); break;
                case 4: library.ReturnBook(); break;
                case 5: library.DeleteBook(); break;
                case 6: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice!\n"); break;
            }
        } while (choice != 6);
    }
}