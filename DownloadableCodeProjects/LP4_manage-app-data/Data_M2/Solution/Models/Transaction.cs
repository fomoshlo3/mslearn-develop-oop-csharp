using System;

namespace Data_M2;

// TASK 5: Create Transaction Class
// Purpose: Represent deposits, withdrawals, and transfers.

public class Transaction
{
    // TASK 5: Step 1 - Add properties for transaction details
    public string TransactionId { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; }
    public double Amount { get; set; }

    // TASK 5: Step 2 - Add a constructor to initialize transaction details
    public Transaction(string transactionId, DateTime date, string type, double amount)
    {
        TransactionId = transactionId;
        Date = date;
        Type = type;
        Amount = amount;
    }
}