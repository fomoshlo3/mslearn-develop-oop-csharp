using System;

namespace BankApp
{
    // TASK 1: Define the AccountType enum
    // TASK 1: Step 1 - Define the AccountType enum
    // - Add an enum named AccountType with values like Checking, Savings, and Business.

    public enum AccountType
    {
        Checking,
        Savings,
        Business
    }

    // TASK 2: Define the Transaction struct
    // TASK 2: Step 1 - Define the Transaction struct
    // - Add a struct named Transaction with properties for Amount, Date, and Description.
    // - Add a constructor to initialize the properties.
    // - Override the ToString method to format transaction details.

    public struct Transaction
    {
        public double Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
    }

    // TASK 3: Define the Customer record
    // TASK 3: Step 1 - Define the Customer record
    // - Add a record named Customer with properties for Name, CustomerId, and Address.

    public record Customer
    {
        public string Name { get; init; }
        public int CustomerId { get; init; }
        public string Address { get; init; }
    }

    public class BankAccount
    {
        // TASK 4: Implement the BankAccount class
        // TASK 4: Step 1 - Add properties for AccountNumber, Balance, AccountHolder, and Type.
        // TASK 4: Step 2 - Add a constructor to initialize the properties.
        // TASK 4: Step 3 - Add a method to deposit money into the account.
        // TASK 4: Step 4 - Add a method to withdraw money from the account.
        // TASK 4: Step 5 - Add a method to display account information.
        // TASK 4: Step 6 - Add a list to track transactions.
        // TASK 4: Step 7 - Add a method to add transactions to the list.
        // TASK 4: Step 8 - Add a method to display all transactions.

        public int AccountNumber { get; }
        public double Balance { get; private set; }

        public BankAccount(int accountNumber, double initialBalance = 0)
        {
            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }

        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Balance: {Balance:C}";
        }
    }
}