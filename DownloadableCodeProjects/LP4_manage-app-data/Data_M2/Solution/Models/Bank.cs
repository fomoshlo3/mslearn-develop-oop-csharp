using System;
using System.Collections.Generic;

namespace Data_M2;

// TASK 2: Create Bank Class
// Purpose: Manage customers and transaction reports.

public class Bank
{
    // TASK 2: Step 1 - Add Name and List<BankCustomer> properties
    public string Name { get; set; } // Removed 'required' keyword
    public List<BankCustomer> Customers { get; private set; }

    // TASK 2: Step 2 - Add a Dictionary<string, List<Transaction>> for transaction reports
    public Dictionary<string, List<Transaction>> TransactionReports { get; private set; }

    // Constructor to initialize properties
    public Bank(string name)
    {
        Name = name; // Initialize the Name property
        Customers = new List<BankCustomer>();
        TransactionReports = new Dictionary<string, List<Transaction>>();
    }

    // TASK 2: Step 3 - Implement AddCustomer method
    public void AddCustomer(BankCustomer customer)
    {
        if (customer != null && !Customers.Contains(customer))
        {
            Customers.Add(customer);
        }
    }

    // TASK 10: Add Dictionary for Reports
    // Purpose: Manage transaction data for reports in the Bank class.

    // TASK 10: Step 1 - Add a method to add transactions to the dictionary
    public void AddTransactionToReport(string key, Transaction transaction)
    {
        if (!TransactionReports.ContainsKey(key))
        {
            TransactionReports[key] = new List<Transaction>();
        }
        TransactionReports[key].Add(transaction);
    }

    // TASK 10: Step 2 - Add a method to retrieve transactions for a specific key
    public List<Transaction> GetTransactionsForKey(string key)
    {
        return TransactionReports.ContainsKey(key) ? TransactionReports[key] : new List<Transaction>();
    }
}