using System;

namespace Classes_M1;

// Task 3

/*

// Create a BankAccount class that includes static members for the next account number and the interest rate.

public class BankAccount
{
    private static int nextAccountNumber = 1;
    public int accountNumber;
    public double balance = 0;
    public static double interestRate = 0;
    public string accountType = "Checking";



    public BankAccount()
    {
        this.accountNumber = nextAccountNumber++;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }

    public BankAccount(double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.balance = balance;
        this.accountType = accountType;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }
}

*/


/* 
// Create a BankAccount class that includes static members for the next account number and the interest rate, and makes the account number read-only.
public class BankAccount
{
    private static int nextAccountNumber = 1;
    public readonly int accountNumber;
    public double balance = 0;
    public static double interestRate = 0;
    public string accountType = "Checking";

    public BankAccount()
    {
        this.accountNumber = nextAccountNumber++;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }

    public BankAccount(double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.balance = balance;
        this.accountType = accountType;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }
}


*/


/* 
// Create a BankAccount class that includes static members for the next account number and the interest rate, makes the account number 
//  read-only, and uses a static constructor to initialize the next account number and interest rate.
public class BankAccount
{
    private static int nextAccountNumber;
    public readonly int accountNumber;
    public double balance = 0;
    public static double interestRate;
    public string accountType = "Checking";

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount()
    {
        this.accountNumber = nextAccountNumber++;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }

    public BankAccount(double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.balance = balance;
        this.accountType = accountType;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }
}

*/


public class BankAccount
{
    private static int nextAccountNumber;
    public readonly int accountNumber;
    public double balance = 0;
    public static double interestRate;
    public string accountType = "Checking";
    public readonly string customerId;

    static BankAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public BankAccount(string customerIdNumber)
    {
        this.accountNumber = nextAccountNumber++;
        this.customerId = customerIdNumber;
        //Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}, customer ID {customerId}");
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.customerId = customerIdNumber;
        this.balance = balance;
        this.accountType = accountType;
        //Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}, customer ID {customerId}");
    }
}







// Task 4




