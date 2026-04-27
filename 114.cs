using System;

// Sealed class
sealed class BankAccount
{
    public int AccountNumber { get; set; }
    public string AccountHolder { get; set; }

    public void Display()
    {
        Console.WriteLine("Account Number: " + AccountNumber);
        Console.WriteLine("Account Holder: " + AccountHolder);
    }
}

// Uncommenting the following line will cause an error
// because sealed class cannot be inherited
// class SavingsAccount : BankAccount { }

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.AccountNumber = 101;
        account.AccountHolder = "Payal";

        account.Display();

        Console.ReadLine();
    }
}