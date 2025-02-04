using System;

namespace Classes_M3;


// Task 1 - review


/* 
public class BankAccount
{
    private static int nextAccountNumber;
    public static double interestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }
}

*/


// Task 2 - Create partial classes (BankAccount)






// Task 3 - Create a static classes (new AccountTypes class and Transactions class that contains BankAccount methods)






// Task 4 - Implement named and optional parameters 


/* 
public class BankAccount
{
    private static int nextAccountNumber;
    public static double interestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }
}

*/

// Task 5 - Implement object initializers and copy constructors 


public class BankAccount
{
    private static int nextAccountNumber;
    public static double interestRate;
    public int AccountNumber { get; }
    public string CustomerId { get; }
    public double Balance { get; set; } = 0;
    public string AccountType { get; set; } = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    // Add a copy constructor here
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }
}


