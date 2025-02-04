using System;

namespace Classes_M3;

// Task 1 - Review

// Task 2 - Create partial classes (BankAccount)

// Task 3 - Create a static classes (new AccountTypes class and Transactions class that contains BankAccount methods)



public static class Transactions
{
    // Method to deposit money into the account
    public static void Deposit(BankAccount account, double amount)
    {
        if (amount > 0)
        {
            account.Balance += amount;
        }
    }

    // Method to withdraw money from the account
    public static bool Withdraw(BankAccount account, double amount)
    {
        if (amount > 0 && account.Balance >= amount)
        {
            account.Balance -= amount;
            return true;
        }
        return false;
    }

    // Method to transfer money to another account
    public static bool Transfer(BankAccount sourceAccount, BankAccount targetAccount, double amount)
    {
        if (Withdraw(sourceAccount, amount))
        {
            Deposit(targetAccount, amount);
            return true;
        }
        return false;
    }

    // Method to apply interest to the account balance
    public static void ApplyInterest(BankAccount account)
    {
        account.Balance += account.Balance * BankAccount.interestRate;
    }
}





// Task 4 - Implement named and optional parameters 






// Task 5 - Implement object initializers and copy constructors 



