using Data_M1;
using System.Globalization;

class Program
{
    static void Main()
    {
        // TASK 1: Create Date and Time Values

        // TASK 1: Step 1 - Get the current date and time
        // NEW CODE WILL GO HERE

        // TASK 1: Step 2 - Get the current date only
        // NEW CODE WILL GO HERE

        // TASK 1: Step 3 - Get the current time only
        // NEW CODE WILL GO HERE

        // TASK 1: Step 4 - Get the current day of the week
        // NEW CODE WILL GO HERE

        // TASK 1: Step 5 - Get the current month and year
        // NEW CODE WILL GO HERE

        // TASK 1: Step 6 - Add days to the current date
        // NEW CODE WILL GO HERE

        // TASK 1: Step 7 - Parse a date string
        // NEW CODE WILL GO HERE

        // TASK 1: Step 8 - Format a date using .ToString() method and "yyyy-MM-dd" format
        // NEW CODE WILL GO HERE

        // TASK 1: Step 9 - Get the current timezone and offset from UTC
        // NEW CODE WILL GO HERE

        // TASK 1: Step 10 - Convert the current time to UTC
        // NEW CODE WILL GO HERE

        // TASK 2: Calculate Date and Time Values for Bank Customer Transactions

        // Create a new customer and accounts
        string firstName = "Tim";
        string lastName = "Shao";
        BankCustomer customer2 = new BankCustomer(firstName, lastName);

        BankAccount account1 = new BankAccount(customer2.CustomerId, 10000);
        BankAccount account2 = new CheckingAccount(customer2.CustomerId, 500, 400);
        BankAccount account3 = new SavingsAccount(customer2.CustomerId, 1000);
        BankAccount account4 = new MoneyMarketAccount(customer2.CustomerId, 2000);

        BankAccount[] bankAccounts = new BankAccount[4];

        bankAccounts[0] = account1;
        bankAccounts[1] = account2;
        bankAccounts[2] = account3;
        bankAccounts[3] = account4;

        // TASK 2: Step 1 - Create a transaction for the current date and time
        // NEW CODE WILL GO HERE

        // TASK 2: Step 2 - Create a transaction for yesterday at 1:15PM
        // NEW CODE WILL GO HERE

        // TASK 2: Step 3 - Create transactions for the first three days of December 2024
        // NEW CODE WILL GO HERE

        // TASK 2: Step 4 - Display the datedTransactions
        // NEW CODE WILL GO HERE

        // TASK 3: Use Date Ranges to Simulate Transactions Programmatically

        // TASK 3: Step 1 - Define a date range starting on December 12, 2024, and ending on February 20, 2025
        // NEW CODE WILL GO HERE

        // TASK 3: Step 2 - Generate transactions for the specified date range using the SimulateTransactions class
        // NEW CODE WILL GO HERE

        // TASK 3: Step 3 - Display the simulated transactions
        // NEW CODE WILL GO HERE

        // TASK 3: Step 4 - Display the number of transactions processed
        // NEW CODE WILL GO HERE

        // Demonstrate inheritance-based polymorphism
        Console.WriteLine("\nDemonstrating inheritance-based polymorphism...");
        // Create a new customer and accounts for inheritance-based polymorphism
        Console.WriteLine("Creating BankCustomer and BankAccount objects...");

        // Create accounts for customer1
        Console.WriteLine("Creating BankAccount objects for customer1...");

        // Demonstrate polymorphism by accessing overridden methods from the base class reference
        Console.WriteLine("\nDemonstrating polymorphism by accessing overridden methods from the base class reference:");

        foreach (BankAccount account in bankAccounts)
        {
            Console.WriteLine(account.DisplayAccountInfo());
        }

        foreach (BankAccount account in bankAccounts)
        {
            if (account is CheckingAccount checkingAccount)
            {
                // CheckingAccount: Withdraw within overdraft limit
                Console.WriteLine("\nCheckingAccount: Attempting to withdraw $600 (within overdraft limit)...");
                checkingAccount.Withdraw(600);
                Console.WriteLine(checkingAccount.DisplayAccountInfo());

                // CheckingAccount: Withdraw exceeding overdraft limit
                Console.WriteLine("\nCheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...");
                checkingAccount.Withdraw(1000);
                Console.WriteLine(checkingAccount.DisplayAccountInfo());
            }
            else if (account is SavingsAccount savingsAccount)
            {
                // SavingsAccount: Withdraw within limit
                Console.WriteLine("\nSavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...");
                savingsAccount.Withdraw(200);
                Console.WriteLine(savingsAccount.DisplayAccountInfo());

                // SavingsAccount: Withdraw exceeding limit
                Console.WriteLine("\nSavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...");
                savingsAccount.Withdraw(900);
                Console.WriteLine(savingsAccount.DisplayAccountInfo());

                // SavingsAccount: Exceeding maximum number of withdrawals per month
                Console.WriteLine("\nSavingsAccount: Exceeding maximum number of withdrawals per month...");
                for (int i = 0; i < 7; i++)
                {
                    Console.WriteLine($"Attempting to withdraw $50 (withdrawal {i + 1})...");
                    savingsAccount.Withdraw(50);
                    Console.WriteLine(savingsAccount.DisplayAccountInfo());
                }
            }
            else if (account is MoneyMarketAccount moneyMarketAccount)
            {
                // MoneyMarketAccount: Withdraw within minimum balance
                Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...");
                moneyMarketAccount.Withdraw(1000);
                Console.WriteLine(moneyMarketAccount.DisplayAccountInfo());

                // MoneyMarketAccount: Withdraw exceeding minimum balance
                Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...");
                moneyMarketAccount.Withdraw(1900);
                Console.WriteLine(moneyMarketAccount.DisplayAccountInfo());
            }
        }
    }
}