using Reuse_M2;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Create a BankCustomer object and various account types
        // Step 1: Create BankCustomer objects
        Console.WriteLine("Creating BankCustomer objects...");
        string firstName = "Tim";
        string lastName = "Shao";

        BankCustomer customer1 = new BankCustomer(firstName, lastName);
        
        // Create accounts for customer1
        Console.WriteLine("Creating BankAccount objects for customer1...");
        CheckingAccount checkingAccount1 = new CheckingAccount(customer1.CustomerId, 500);
        SavingsAccount savingsAccount1 = new SavingsAccount(customer1.CustomerId, 1000);
        MoneyMarketAccount moneyMarketAccount1 = new MoneyMarketAccount(customer1.CustomerId, 2000);
        CertificateOfDeposit certificateOfDeposit1 = new CertificateOfDeposit(customer1.CustomerId, 5000, 6);
        //BankAccount bankAccount1 = new BankAccount(customer1.CustomerId, 10000);  // generates an error because BankAccount is abstract

        // Demonstrate inheritance of the DisplayAccountInfo method in the base class
        Console.WriteLine(checkingAccount1.DisplayAccountInfo());
        Console.WriteLine(savingsAccount1.DisplayAccountInfo());
        Console.WriteLine(moneyMarketAccount1.DisplayAccountInfo());
        Console.WriteLine(certificateOfDeposit1.DisplayAccountInfo());

        // Demonstrate the special behavior implemented by the Withdraw method of the derived classes
        Console.WriteLine("\nDemonstrating specialized Withdraw behavior:");

        // CheckingAccount: Withdraw within overdraft limit
        Console.WriteLine("\nCheckingAccount: Attempting to withdraw $600 (within overdraft limit)...");
        checkingAccount1.Withdraw(600);
        Console.WriteLine(checkingAccount1.DisplayAccountInfo());

        // CheckingAccount: Withdraw exceeding overdraft limit
        Console.WriteLine("\nCheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...");
        checkingAccount1.Withdraw(1000);
        Console.WriteLine(checkingAccount1.DisplayAccountInfo());

        // SavingsAccount: Withdraw within limit
        Console.WriteLine("\nSavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...");
        savingsAccount1.Withdraw(200);
        Console.WriteLine(savingsAccount1.DisplayAccountInfo());

        // SavingsAccount: Withdraw exceeding limit
        Console.WriteLine("\nSavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...");
        savingsAccount1.Withdraw(900);
        Console.WriteLine(savingsAccount1.DisplayAccountInfo());

        // SavingsAccount: Exceeding maximum number of withdrawals per month
        Console.WriteLine("\nSavingsAccount: Exceeding maximum number of withdrawals per month...");
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine($"Attempting to withdraw $50 (withdrawal {i + 1})...");
            savingsAccount1.Withdraw(50);
            Console.WriteLine(savingsAccount1.DisplayAccountInfo());
        }

        // MoneyMarketAccount: Withdraw within minimum balance
        Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...");
        moneyMarketAccount1.Withdraw(1000);
        Console.WriteLine(moneyMarketAccount1.DisplayAccountInfo());

        // MoneyMarketAccount: Withdraw exceeding minimum balance
        Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...");
        moneyMarketAccount1.Withdraw(1900);
        Console.WriteLine(moneyMarketAccount1.DisplayAccountInfo());

        // CertificateOfDeposit: Withdraw before maturity with penalty
        Console.WriteLine("\nCertificateOfDeposit: Attempting to withdraw $1000 before maturity (with penalty)...");
        certificateOfDeposit1.Withdraw(1000);
        Console.WriteLine(certificateOfDeposit1.DisplayAccountInfo());
    }
}
