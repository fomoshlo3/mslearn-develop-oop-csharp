using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank App!");

            // Create a basic BankAccount
            BankAccount account = new BankAccount(12345678, 500);
            Console.WriteLine(account.DisplayAccountInfo());

            // Perform a deposit
            account.Deposit(200);
            Console.WriteLine("After deposit:");
            Console.WriteLine(account.DisplayAccountInfo());

            // Perform a withdrawal
            bool success = account.Withdraw(100);
            Console.WriteLine(success ? "Withdrawal successful." : "Withdrawal failed.");
            Console.WriteLine("After withdrawal:");
            Console.WriteLine(account.DisplayAccountInfo());

            Console.WriteLine("Features to be implemented...");
        }
    }
}