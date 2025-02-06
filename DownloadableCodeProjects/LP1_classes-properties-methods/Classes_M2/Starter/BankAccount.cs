using System;

namespace Classes_M2;

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
    }

    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.accountNumber = nextAccountNumber++;
        this.customerId = customerIdNumber;
        this.balance = balance;
        this.accountType = accountType;
    }
}
