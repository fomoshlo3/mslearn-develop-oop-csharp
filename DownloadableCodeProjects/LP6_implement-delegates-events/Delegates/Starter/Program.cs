using Delegates;

using System;
using System.IO;
using System.Text;
using System.Text.Json;

class Program
{
    static async Task Main()
    {
        // Create a bank object
        Bank bank = new Bank();

        // Generate 2 years of transactions for 50 customers
        GenerateCustomerDataAsync;

        await Task.Delay(2000);

        // Load the customer data asynchronously from the file
        var asyncLoadTask = LoadCustomerLogsAsync.ReadCustomerDataAsync(bank);

        // Wait for the async task to complete
        await asyncLoadTask;

        int countBank2Customers = 0;
        int countBank2Accounts = 0;
        int countBank2Transactions = 0;

        foreach (var customer in bank2.GetAllCustomers())
        {
            countBank2Customers++;
            foreach (var account in customer.Accounts)
            {
                countBank2Accounts++;
                foreach (var transaction in account.Transactions)
                {
                    countBank2Transactions++;
                }
            }
        }

        Console.WriteLine($"\nBank 2 information...");
        Console.WriteLine($"Number of customers: {countBank2Customers}");
        Console.WriteLine($"Number of accounts: {countBank2Accounts}");
        Console.WriteLine($"Number of transactions: {countBank2Transactions}");
    }
}
