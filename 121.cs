using System;

// Custom exception class
class AgeException : Exception
{
    public AgeException(string message) : base(message)
    {
    }
}

class Program
{
    static void CheckAge(int age)
    {
        if (age < 18)
        {
            // Throw custom exception
            throw new AgeException("Age must be 18 or older.");
        }
        else
        {
            Console.WriteLine("Age is valid: " + age);
        }
    }

    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());

            CheckAge(age);
        }
        catch (AgeException ex)
        {
            Console.WriteLine("Custom Exception: " + ex.Message);
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Please enter a valid number.");
        }
        finally
        {
            Console.WriteLine("Program execution completed.");
        }

        Console.ReadLine();
    }
}