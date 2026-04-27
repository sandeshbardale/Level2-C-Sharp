using System;
using System.Data.SqlClient;
using System.IO;
using BCrypt.Net;

class SecureApp
{
    static void Main()
    {
        try
        {
            Console.WriteLine("==== Secure C# Demo ====");

            // 1. Input Validation
            Console.Write("Enter your username: ");
            string username = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(username) || username.Length > 20)
            {
                Console.WriteLine("Invalid username!");
                return;
            }

            Console.Write("Enter your password: ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                Console.WriteLine("Invalid password!");
                return;
            }

            // 2. Hash Password securely
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            Console.WriteLine("Password hashed securely.");

            // 3. Database operation with parameterized query
            string connectionString = "YourConnectionStringHere";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Users (Username, PasswordHash) VALUES (@username, @password)";
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    int rows = cmd.ExecuteNonQuery();
                    Console.WriteLine(rows > 0 ? "User saved to database." : "Database error.");
                }
            }

            // 4. Secure File Handling
            Console.Write("Enter filename to save: ");
            string fileName = Console.ReadLine();
            string[] allowedExtensions = { ".txt", ".log" };
            string ext = Path.GetExtension(fileName).ToLower();

            if (!allowedExtensions.Contains(ext))
            {
                Console.WriteLine("Invalid file type.");
                return;
            }

            string safePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Path.GetFileName(fileName));
            File.WriteAllText(safePath, $"User: {username}\nHashed Password: {hashedPassword}");
            Console.WriteLine($"Data saved securely to {safePath}.");

        }
        catch (SqlException sqlEx)
        {
            Console.WriteLine("Database error occurred. Try again later.");
            Console.Error.WriteLine(sqlEx.Message); // Log safely
        }
        catch (Exception ex)
        {
            Console.WriteLine("An unexpected error occurred.");
            Console.Error.WriteLine(ex.Message); // Log safely
        }
    }
}