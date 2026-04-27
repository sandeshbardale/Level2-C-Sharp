using System;
using System.Collections.Generic;
using System.Linq;

// Bank Account class
class BankAccount
{
    public int AccountNumber { get; set; }
    public string AccountHolder { get; set; }
    public decimal Balance { get; set; }
}

// Banking System class
class BankingSystem
{
    private List<BankAccount> accounts = new List<BankAccount>();
    private int nextAccountNumber = 1001;

    // Create a new account
    public void CreateAccount()
    {
        Console.Write("Enter Account Holder Name: ");
        string name = Console.ReadLine();

        BankAccount account = new BankAccount
        {
            AccountNumber = nextAccountNumber++,
            AccountHolder = name,
            Balance = 0
        };
        accounts.Add(account);
        Console.WriteLine($"Account created successfully! Account Number: {account.AccountNumber}\n");
    }

    // Deposit money
    public void Deposit()
    {
        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        var account = accounts.FirstOrDefault(a => a.AccountNumber == accNo);
        if (account == null)
        {
            Console.WriteLine("Account not found!\n");
            return;
        }

        Console.Write("Enter Amount to Deposit: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        if (amount <= 0)
        {
            Console.WriteLine("Invalid amount!\n");
            return;
        }

        account.Balance += amount;
        Console.WriteLine($"Deposited {amount:C} successfully. New Balance: {account.Balance:C}\n");
    }

    // Withdraw money
    public void Withdraw()
    {
        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        var account = accounts.FirstOrDefault(a => a.AccountNumber == accNo);
        if (account == null)
        {
            Console.WriteLine("Account not found!\n");
            return;
        }

        Console.Write("Enter Amount to Withdraw: ");
        decimal amount = decimal.Parse(Console.ReadLine());

        if (amount <= 0 || amount > account.Balance)
        {
            Console.WriteLine("Invalid or insufficient funds!\n");
            return;
        }

        account.Balance -= amount;
        Console.WriteLine($"Withdrawn {amount:C} successfully. New Balance: {account.Balance:C}\n");
    }

    // Check balance
    public void CheckBalance()
    {
        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        var account = accounts.FirstOrDefault(a => a.AccountNumber == accNo);
        if (account == null)
        {
            Console.WriteLine("Account not found!\n");
            return;
        }

        Console.WriteLine($"Account Holder: {account.AccountHolder}");
        Console.WriteLine($"Account Balance: {account.Balance:C}\n");
    }

    // Delete account
    public void DeleteAccount()
    {
        Console.Write("Enter Account Number: ");
        int accNo = int.Parse(Console.ReadLine());

        var account = accounts.FirstOrDefault(a => a.AccountNumber == accNo);
        if (account == null)
        {
            Console.WriteLine("Account not found!\n");
            return;
        }

        accounts.Remove(account);
        Console.WriteLine($"Account {accNo} deleted successfully!\n");
    }
}

// Main Program
class Program
{
    static void Main()
    {
        BankingSystem bank = new BankingSystem();
        int choice;

        do
        {
            Console.WriteLine("=== Banking System ===");
            Console.WriteLine("1. Create Account");
            Console.WriteLine("2. Deposit");
            Console.WriteLine("3. Withdraw");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Delete Account");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());
            Console.WriteLine();

            switch (choice)
            {
                case 1: bank.CreateAccount(); break;
                case 2: bank.Deposit(); break;
                case 3: bank.Withdraw(); break;
                case 4: bank.CheckBalance(); break;
                case 5: bank.DeleteAccount(); break;
                case 6: Console.WriteLine("Exiting..."); break;
                default: Console.WriteLine("Invalid choice!\n"); break;
            }
        } while (choice != 6);
    }
}