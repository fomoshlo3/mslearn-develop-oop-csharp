using System;

namespace Reuse_M2;

public class CheckingAccount : BankAccount
{
    public double OverdraftLimit { get; set; }

    public static double DefaultOverdraftLimit { get; private set; }
    public static double DefaultInterestRate { get; private set; }

    static CheckingAccount()
    {
        DefaultOverdraftLimit = 500;
        DefaultInterestRate = 0.00;
    }

    public CheckingAccount(string customerIdNumber, double balance = 200, double overdraftLimit = 500)
        : base(customerIdNumber, balance, "Checking")
    {
        OverdraftLimit = overdraftLimit;
        //InterestRate = DefaultInterestRate; // Set the interest rate to the default value
    }

    public override double InterestRate
    {
        get { return DefaultInterestRate; }
        protected set { DefaultInterestRate = value; }
    }

    public override bool Withdraw(double amount)
    {
        if (amount > 0 && Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;

            // Check if the account is overdrawn
            if (Balance < 0)
            {
                double overdraftFee = AccountCalculations.CalculateOverdraftFee(Math.Abs(Balance), BankAccount.OverdraftRate, BankAccount.MaxOverdraftFee);
                Balance -= overdraftFee;
                Console.WriteLine($"Overdraft fee of ${overdraftFee} applied.");
            }

            return true;
        }
        return false;
    }

    public override string DisplayAccountInfo()
    {
        return base.DisplayAccountInfo() + $", Overdraft Limit: {OverdraftLimit}";
    }
}
