using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.Write("Enter first number: ");
            int num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter second number: ");
            int num2 = Convert.ToInt32(Console.ReadLine());

            int result = num1 / num2;  // May throw DivideByZeroException
            Console.WriteLine("Result: " + result);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error: Division by zero is not allowed.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Error: Please enter a valid integer.");
        }
        finally
        {
            Console.WriteLine("This block always executes, closing resources if needed.");
        }

        Console.ReadLine();
    }
}