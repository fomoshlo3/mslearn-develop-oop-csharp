using System;

namespace BankApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Bank App!");

            // TASK 5: Display Basic Bank Account Information
            // TASK 5: Step 1 - Create a BankAccount object.
            // TASK 5: Step 2 - Call the DisplayAccountInfo method to output account details.

            // Create a BankAccount
            Customer customer1 = new("Tim Shao", "C123456789", "123 Elm Street");
            BankAccount account = new(12345678, AccountType.Checking, customer1, 500);
            Console.WriteLine(account.DisplayAccountInfo());

            // TASK 6: Perform Transactions
            // TASK 6: Step 1 - Call the AddTransaction method to add a deposit to the account.
            // TASK 6: Step 2 - Call the AddTransaction method to add a withdrawal to the account.

            // Add Transactions
            account.AddTransaction(200, "Deposit");
            account.AddTransaction(-50, "ATM Withdrawal");

            // TASK 7: Display Transaction History
            // TASK 7: Step 1 - Call the DisplayTransactions method to output the list of transactions.

            // Display Account Info and Transactions
            Console.WriteLine(account.DisplayAccountInfo());
            account.DisplayTransactions();

            // TASK 8: Demonstrate Record Comparison
            // TASK 8: Step 1 - Create two Customer objects with identical properties.
            // TASK 8: Step 2 - Compare the two Customer objects using the == operator.

            Customer customer2 = new("Tim Shao", "C123456789", "123 Elm Street");
            Console.WriteLine($"Are customers equal? {customer1 == customer2}");

            // TASK 9: Demonstrate Immutability of Structs
            // TASK 9: Step 1 - Create a Transaction object.
            // TASK 9: Step 2 - Display the transaction details using the ToString method.

            Transaction transaction = new(100, DateTime.Now, "Test Transaction");
            Console.WriteLine($"Immutable Transaction: {transaction}");
        }
    }
}