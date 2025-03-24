using System;
// TASK 6: Step 1 - Add using directive for collections - System.Collections.Generic;
using System.Collections.Generic;

namespace Data_M2;

// TASK 6: Create SimulateDepositWithdrawTransfer Class
// Purpose: Simulate and log transactions.

public class SimulateDepositWithdrawTransfer
{
    // TASK 6: Step 2 - Add methods to simulate deposits
    public void SimulateDeposit(BankAccount account, double amount)
    {
        if (account != null && amount > 0)
        {
            account.Deposit(amount);
            Console.WriteLine($"Deposit of {amount:C} made to Account {account.AccountNumber}.");
        }
    }

    // TASK 6: Step 3 - Add methods to simulate withdrawals
    public void SimulateWithdrawal(BankAccount account, double amount)
    {
        if (account != null && amount > 0)
        {
            if (account.Withdraw(amount))
            {
                Console.WriteLine($"Withdrawal of {amount:C} made from Account {account.AccountNumber}.");
            }
            else
            {
                Console.WriteLine($"Withdrawal of {amount:C} failed for Account {account.AccountNumber} (insufficient funds).");
            }
        }
    }

    // TASK 6: Step 4 - Add methods to simulate transfers
    public void SimulateTransfer(BankAccount sourceAccount, BankAccount targetAccount, double amount)
    {
        if (sourceAccount != null && targetAccount != null && amount > 0)
        {
            if (sourceAccount.Transfer(targetAccount, amount))
            {
                Console.WriteLine($"Transfer of {amount:C} made from Account {sourceAccount.AccountNumber} to Account {targetAccount.AccountNumber}.");
            }
            else
            {
                Console.WriteLine($"Transfer of {amount:C} failed from Account {sourceAccount.AccountNumber} to Account {targetAccount.AccountNumber} (insufficient funds).");
            }
        }
    }
 }