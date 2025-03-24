using System;

// TASK 4: Step 1 - Add System.Collections.Generic namespace
using System.Collections.Generic;

namespace Data_M2;

public class BankAccount : IBankAccount
{
    private static int s_nextAccountNumber;

    // Public read-only static properties
    public static double TransactionRate { get; private set; }
    public static double MaxTransactionFee { get; private set; }
    public static double OverdraftRate { get; private set; }
    public static double MaxOverdraftFee { get; private set; }

    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; internal set; } = 0;
    public string AccountType { get; set; } = "Checking";
    public virtual double InterestRate { get; protected set; } // Virtual property to allow overriding in derived classes

    // TASK 4: Step 2 - Add Owner property to reference BankCustomer
    public BankCustomer Owner { get; set; }

    // TASK 4: Step 3 - Add List<Transaction> property to track transactions
    public List<Transaction> Transactions { get; set; } = new List<Transaction>();

    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        TransactionRate = 0.01; // Default transaction rate for wire transfers and cashier's checks
        MaxTransactionFee = 10; // Maximum transaction fee for wire transfers and cashier's checks
        OverdraftRate = 0.05; // Default penalty rate for an overdrawn checking account (negative balance)
        MaxOverdraftFee = 10; // Maximum overdraft fee for an overdrawn checking account
    }

    public BankAccount(string customerIdNumber, double balance = 200, string accountType = "Checking", BankCustomer? owner = null)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
        this.Owner = owner ?? new BankCustomer("Default", "Customer"); // Initialize with a default owner if none is provided
    }

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
        this.Owner = existingAccount.Owner; // Copy the owner from the existing account
    }

    // TASK 4: Step 4a - Add logic to log the deposit transaction
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            AddTransaction(new Transaction(
                Guid.NewGuid().ToString(), // Generate a unique transaction ID
                DateTime.Now,
                "Deposit",
                amount
            ));
        }
    }

    // TASK 4: Step 4b - Add logic to log the withdrawal transaction
    public virtual bool Withdraw(double amount)
    {
        if (amount > 0 && Balance >= amount)
        {
            Balance -= amount;
            AddTransaction(new Transaction(
                Guid.NewGuid().ToString(),
                DateTime.Now,
                "Withdrawal",
                amount
            ));
            return true;
        }
        return false;
    }

    // TASK 4: Step 4c - Add logic to log the transfer transaction
    public bool Transfer(IBankAccount targetAccount, double amount)
    {
        if (Withdraw(amount))
        {
            targetAccount.Deposit(amount);
            AddTransaction(new Transaction(
                Guid.NewGuid().ToString(),
                DateTime.Now,
                "Transfer",
                amount
            ));
            return true;
        }
        return false;
    }

    // TASK 4: Step 4d - Add logic to log the interest transaction
    public void ApplyInterest(double years)
    {
        double interest = AccountCalculations.CalculateCompoundInterest(Balance, InterestRate, years);
        Balance += interest;
        AddTransaction(new Transaction(
            Guid.NewGuid().ToString(),
            DateTime.Now,
            "Interest",
            interest
        ));
    }

    // TASK 4: Step 4e - Add logic to log the refund transaction
    public void ApplyRefund(double refund)
    {
        Balance += refund;
        AddTransaction(new Transaction(
            Guid.NewGuid().ToString(),
            DateTime.Now,
            "Refund",
            refund
        ));
    }

    // TASK 4: Step 4f - Add logic to log the cashier's check transaction
    public bool IssueCashiersCheck(double amount)
    {
        if (amount > 0 && Balance >= amount + BankAccount.MaxTransactionFee)
        {
            Balance -= amount;
            double fee = AccountCalculations.CalculateTransactionFee(amount, BankAccount.TransactionRate, BankAccount.MaxTransactionFee);
            Balance -= fee;
            AddTransaction(new Transaction(
                Guid.NewGuid().ToString(),
                DateTime.Now,
                "Cashier's Check",
                amount
            ));
            AddTransaction(new Transaction(
                Guid.NewGuid().ToString(),
                DateTime.Now,
                "Transaction Fee",
                fee
            ));
            return true;
        }
        return false;
    }

    // Method to log transactions
    private void AddTransaction(Transaction transaction)
    {
        if (transaction != null)
        {
            Transactions.Add(transaction);
        }
    }

    // Method to display account information
    public virtual string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance:C}, Interest Rate: {InterestRate:P}, Customer ID: {CustomerId}";
    }
}