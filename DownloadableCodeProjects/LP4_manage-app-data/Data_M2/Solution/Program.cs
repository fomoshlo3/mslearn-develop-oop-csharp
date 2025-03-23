using Data_M2;
using System.Globalization;
// TASK 7: Step 1 - Add System.Collections.Generic namespace
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // TASK 1: Create and Manage Bank, Customers, and Accounts
        // This task will set up the initial structure for the bank system.

        // TASK 1: Step 1 - Create a Bank object
        Bank myBank = new Bank("MyBank");

        // TASK 1: Step 2 - Create BankCustomer and BankAccount objects
        BankCustomer customer1 = new BankCustomer("Alice", "Smith");
        BankCustomer customer2 = new BankCustomer("Bob", "Johnson");

        BankAccount account1 = new CheckingAccount(customer1.CustomerId, 1000);
        BankAccount account2 = new SavingsAccount(customer2.CustomerId, 2000);

        // TASK 1: Step 3 - Add accounts to customers and customers to the bank
        customer1.AddAccount(account1);
        customer2.AddAccount(account2);

        myBank.AddCustomer(customer1);
        myBank.AddCustomer(customer2);

        // TASK 1: Step 4 - Simulate deposits, withdrawals, and transfers
        SimulateDepositWithdrawTransfer simulator = new SimulateDepositWithdrawTransfer();
        simulator.SimulateDeposit(account1, 500);
        simulator.SimulateWithdrawal(account2, 300);
        simulator.SimulateTransfer(account1, account2, 200);

        // TASK 1: Step 5 - Use a HashSet to ensure unique transactions
        HashSet<Transaction> uniqueTransactions = new HashSet<Transaction>(account1.Transactions);
        uniqueTransactions.UnionWith(account2.Transactions);

        // TASK 1: Step 6 - Generate a report of transactions within a date range
        Console.WriteLine("\nTransaction Report:");
        foreach (var transaction in uniqueTransactions)
        {
            Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
        }

        // TASK 1: Step 7 - Display bank and customer information
        // Purpose: Test the program by displaying all customers and their accounts.
        Console.WriteLine("\nBank and Customer Information:");
        foreach (var customer in myBank.Customers)
        {
            Console.WriteLine($"Customer: {customer.ReturnFullName()}");
            foreach (var account in customer.Accounts)
            {
                Console.WriteLine(account.DisplayAccountInfo());
            }
        }

        // TASK 7: Use HashSet in Program.cs
        // Purpose: Ensure unique transactions in reports.

        // TASK 7: Step 3 - Replace List<Transaction> with HashSet<Transaction> and generate a report of unique transactions
        // This step ensures:
        //   - Transactions are stored in a HashSet<Transaction> to avoid duplicates.
        //   - Logic is updated to work with HashSet<Transaction> instead of List<Transaction>.
        //   - A report of unique transactions is generated and displayed.
        Console.WriteLine("\nUnique Transactions Report:");
        foreach (var transaction in uniqueTransactions)
        {
            Console.WriteLine($"Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
        }

        // TASK 8: Generate Reports in Program.cs
        // Purpose: Loop through customers, accounts, and transactions to generate date-range reports.

        // TASK 8: Step 1 - Define a date range for the report
        DateTime startDate = new DateTime(2025, 1, 1); // Example start date
        DateTime endDate = new DateTime(2025, 12, 31); // Example end date

        Console.WriteLine("\nDate-Range Transaction Report");

        // TASK 8: Step 2 - Loop through customers, accounts, and filter transactions by date range
        // This step performs the following:
        //   - Loops through each customer and their accounts.
        //   - Filters transactions within the specified date range.
        //   - Displays the transaction details for each filtered transaction.
        foreach (var customer in myBank.Customers)
        {
            Console.WriteLine($"\nCustomer: {customer.ReturnFullName()}");

            foreach (var account in customer.Accounts)
            {
                Console.WriteLine($"  Account Number: {account.AccountNumber}, Type: {account.AccountType}");

                var filteredTransactions = account.Transactions
                    .Where(t => t.Date >= startDate && t.Date <= endDate);

                foreach (var transaction in filteredTransactions)
                {
                    Console.WriteLine($"    Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
                }
            }
        }

        // TASK 9: Handle Transfer Duplication
        // Purpose: Avoid counting the same transfer twice in reports.
        // This step ensures:
        //   - Transfers between accounts are only counted once.
        //   - A HashSet<Transaction> is used to track unique transfer transactions.
        //   - The Transaction class does not include SourceAccount or TargetAccount properties,
        //     so only basic transfer details are displayed.

        // TASK 9: Step 1 - Create a HashSet to store unique transfer transactions
        HashSet<Transaction> uniqueTransfers = new HashSet<Transaction>();

        // TASK 9: Step 2 - Loop through customers and their accounts
        foreach (var customer in myBank.Customers)
        {
            foreach (var account in customer.Accounts)
            {
                // TASK 9: Step 3 - Filter transfer transactions and add them to the HashSet
                var transferTransactions = account.Transactions
                    .Where(t => t.Type == "Transfer");

                foreach (var transaction in transferTransactions)
                {
                    uniqueTransfers.Add(transaction);
                }
            }
        }

        // TASK 9: Step 4 - Display the unique transfer transactions
        Console.WriteLine("\nUnique Transfers Report");
        foreach (var transaction in uniqueTransfers)
        {
            Console.WriteLine($"Transfer ID: {transaction.TransactionId}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
        }

        // TASK 10: Add Dictionary for Reports
        // Purpose: Manage transaction data for reports in the Bank class.

        // TASK 10: Step 1 - Populate the dictionary with transaction data
        foreach (var customer in myBank.Customers)
        {
            foreach (var account in customer.Accounts)
            {
                foreach (var transaction in account.Transactions)
                {
                    myBank.AddTransactionToReport(account.AccountNumber.ToString(), transaction);
                }
            }
        }

        // TASK 10: Step 2 - Retrieve and display transactions from the dictionary
        Console.WriteLine("\nTransactions from the Dictionary:");
        foreach (var key in myBank.TransactionReports.Keys)
        {
            Console.WriteLine($"Account: {key}");
            foreach (var transaction in myBank.TransactionReports[key])
            {
                Console.WriteLine($"  Transaction ID: {transaction.TransactionId}, Type: {transaction.Type}, Amount: {transaction.Amount:C}, Date: {transaction.Date}");
            }
        }

        // Example: Create a BankCustomer and display their information
        BankCustomer exampleCustomer = new BankCustomer("Isabel", "Robledo");
        Console.WriteLine($"Example Customer Created: {exampleCustomer.FirstName} {exampleCustomer.LastName}");

        // Example: Use a method from the BankCustomer class
        exampleCustomer.AddAccount(new BankAccount("Savings", 1000.00));
        Console.WriteLine($"Account added for {exampleCustomer.FirstName} with balance: {exampleCustomer.Accounts[0].Balance}");
    }
}