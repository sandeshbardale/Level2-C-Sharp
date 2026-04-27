using System;

class ThrowExample
{
    static void CheckAge(int age)
    {
        if (age < 18)
        {
            // Throwing an exception manually
            throw new ArgumentException("Age must be 18 or above.");
        }
        else
        {
            Console.WriteLine("Access granted!");
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
        catch (ArgumentException ex)
        {
            Console.WriteLine("Exception caught: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("Program executed successfully.");
        }
    }
}