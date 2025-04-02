using System;
using System.Collections.Generic;

namespace BankApp
{
    // TASK 1: Define the AccountType enum
    // TASK 1: Step 1 - Define the AccountType enum
    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }

    public static class AccountTypeExtensions
    {
        // TASK 1: Step 2 - Add an extension method to provide descriptions for each AccountType.
        public static string GetDescription(this AccountType accountType)
        {
            return accountType switch
            {
                AccountType.Checking => "A standard checking account.",
                AccountType.Savings => "A savings account with interest.",
                AccountType.Business => "A business account for companies.",
                _ => "Unknown account type."
            };
        }
    }

    // TASK 2: Define the Transaction struct
    // TASK 2: Step 1 - Define the Transaction struct
    public readonly struct Transaction
    {
        public double Amount { get; }
        public DateTime Date { get; }
        public string Description { get; }

        public Transaction(double amount, DateTime date, string description)
        {
            Amount = amount;
            Date = date;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Date.ToShortDateString()}: {Description} - {Amount:C}";
        }
    }

    // TASK 3: Define the Customer record
    // TASK 3: Step 1 - Define the Customer record
    public record Customer(string Name, string CustomerId, string Address);

    // TASK 4: Implement the BankAccount class
    // TASK 4: Step 1 - Add properties for AccountNumber, Balance, AccountHolder, and Type.
    public class BankAccount
    {
        public int AccountNumber { get; }
        public AccountType Type { get; }
        public Customer AccountHolder { get; }
        public double Balance { get; private set; }

        // TASK 4: Step 2 - Add a constructor to initialize the properties.
        public BankAccount(int accountNumber, AccountType type, Customer accountHolder, double initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Type = type;
            AccountHolder = accountHolder;
            Balance = initialBalance;
        }

        // TASK 4: Step 3 - Add a method to deposit money into the account.
        public void AddTransaction(double amount, string description)
        {
            Balance += amount;
            Transactions.Add(new Transaction(amount, DateTime.Now, description));
        }

        // TASK 4: Step 4 - Add a method to withdraw money from the account.
        public string DisplayAccountInfo()
        {
            return $"Account Holder: {AccountHolder.Name}, Account Number: {AccountNumber}, Type: {Type}, Balance: {Balance:C}";
        }

        // TASK 4: Step 5 - Add a method to display account information.
        private List<Transaction> Transactions { get; } = new();

        // TASK 4: Step 6 - Add a list to track transactions.
        public void DisplayTransactions()
        {
            Console.WriteLine("Transactions:");
            foreach (var transaction in Transactions)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}