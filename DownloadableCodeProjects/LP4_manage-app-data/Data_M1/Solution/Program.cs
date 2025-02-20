using Data_M1;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Step 1: Create a BankCustomer object and various account types

        // Create customer1
        Console.WriteLine("Creating BankCustomer and BankAccount objects...");
        string firstName = "Tim";
        string lastName = "Shao";
        BankCustomer customer1 = new PremiumCustomer(firstName, lastName);

        // Create accounts for customer1
        Console.WriteLine("Creating BankAccount objects for customer1...");
        BankAccount bankAccount1 = new BankAccount(customer1.CustomerId, 10000);
        BankAccount bankAccount2 = new CheckingAccount(customer1.CustomerId, 500, 400);
        BankAccount bankAccount3 = new SavingsAccount(customer1.CustomerId, 1000);
        BankAccount bankAccount4 = new MoneyMarketAccount(customer1.CustomerId, 2000);
        BankAccount bankAccount5 = new CertificateOfDeposit(customer1.CustomerId, 5000, 6);

        // Step 2: Demonstrate polymorphism by accessing overridden methods from the base class reference
        Console.WriteLine("\nDemonstrating polymorphism by accessing overridden methods from the base class reference:");

        Console.WriteLine(bankAccount1.DisplayAccountInfo());
        Console.WriteLine(bankAccount2.DisplayAccountInfo());
        Console.WriteLine(bankAccount3.DisplayAccountInfo());
        Console.WriteLine(bankAccount4.DisplayAccountInfo());
        Console.WriteLine(bankAccount5.DisplayAccountInfo());

        // CheckingAccount: Withdraw within overdraft limit
        Console.WriteLine("\nCheckingAccount: Attempting to withdraw $600 (within overdraft limit)...");
        bankAccount2.Withdraw(600);
        Console.WriteLine(bankAccount2.DisplayAccountInfo());

        // CheckingAccount: Withdraw exceeding overdraft limit
        Console.WriteLine("\nCheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...");
        bankAccount2.Withdraw(1000);
        Console.WriteLine(bankAccount1.DisplayAccountInfo());

        // SavingsAccount: Withdraw within limit
        Console.WriteLine("\nSavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...");
        bankAccount3.Withdraw(200);
        Console.WriteLine(bankAccount3.DisplayAccountInfo());

        // SavingsAccount: Withdraw exceeding limit
        Console.WriteLine("\nSavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...");
        bankAccount3.Withdraw(900);
        Console.WriteLine(bankAccount3.DisplayAccountInfo());

        // SavingsAccount: Exceeding maximum number of withdrawals per month
        Console.WriteLine("\nSavingsAccount: Exceeding maximum number of withdrawals per month...");
        for (int i = 0; i < 7; i++)
        {
            Console.WriteLine($"Attempting to withdraw $50 (withdrawal {i + 1})...");
            bankAccount3.Withdraw(50);
            Console.WriteLine(bankAccount3.DisplayAccountInfo());
        }

        // MoneyMarketAccount: Withdraw within minimum balance
        Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...");
        bankAccount4.Withdraw(1000);
        Console.WriteLine(bankAccount4.DisplayAccountInfo());

        // MoneyMarketAccount: Withdraw exceeding minimum balance
        Console.WriteLine("\nMoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...");
        bankAccount4.Withdraw(1900);
        Console.WriteLine(bankAccount4.DisplayAccountInfo());

        // CertificateOfDeposit: Withdraw before maturity with penalty
        Console.WriteLine("\nCertificateOfDeposit: Attempting to withdraw $1000 before maturity (with penalty)...");
        bankAccount5.Withdraw(1000);
        Console.WriteLine(bankAccount5.DisplayAccountInfo());

        // Step 3: Demonstrate polymorphism by using interfaces to create instances of derived classes
        Console.WriteLine("\nDemonstrating polymorphism by using interfaces to create instances of derived classes:");

        // Create instances of BankCustomer and BankAccount using interfaces
        firstName = "Sandy";
        lastName = "Zoeng";
        IBankCustomer customer2 = new StandardCustomer(firstName, lastName);
        IBankAccount account1 = new BankAccount(customer2.CustomerId, 10000);
        IBankAccount account2 = new CheckingAccount(customer2.CustomerId, 500, 400);
        IBankAccount account3 = new SavingsAccount(customer2.CustomerId, 1000);

        Console.WriteLine(account1.DisplayAccountInfo());
        Console.WriteLine(account2.DisplayAccountInfo());
        Console.WriteLine(account3.DisplayAccountInfo());

        // Step 4: Demonstrate polymorphism based on interfaces
        Console.WriteLine("\nDemonstrating polymorphism based on interfaces:");

        // Create instances of IReportGenerator using interfaces
        IMonthlyReportGenerator customerMonthlyReportGenerator = new CustomerReportGenerator(customer2);
        IQuarterlyReportGenerator customerQuarterlyReportGenerator = new CustomerReportGenerator(customer2);
        IYearlyReportGenerator customerYearlyReportGenerator = new CustomerReportGenerator(customer2);

        customerMonthlyReportGenerator.GenerateMonthlyReport();
        customerMonthlyReportGenerator.GenerateCurrentMonthToDateReport();
        customerMonthlyReportGenerator.GeneratePrevious30DayReport();
        customerQuarterlyReportGenerator.GenerateQuarterlyReport();
        customerYearlyReportGenerator.GeneratePreviousYearReport();
        customerYearlyReportGenerator.GenerateCurrentYearToDateReport();
        customerYearlyReportGenerator.GenerateLast365DaysReport();

        IMonthlyReportGenerator accountMonthlyReportGenerator = new AccountReportGenerator(account1);
        IQuarterlyReportGenerator accountQuarterlyReportGenerator = new AccountReportGenerator(account1);
        IYearlyReportGenerator accountYearlyReportGenerator = new AccountReportGenerator(account1); 

        accountMonthlyReportGenerator.GenerateMonthlyReport();
        accountMonthlyReportGenerator.GenerateCurrentMonthToDateReport();
        accountMonthlyReportGenerator.GeneratePrevious30DayReport();
        accountQuarterlyReportGenerator.GenerateQuarterlyReport();
        accountYearlyReportGenerator.GeneratePreviousYearReport();
        accountYearlyReportGenerator.GenerateCurrentYearToDateReport();
        accountYearlyReportGenerator.GenerateLast365DaysReport();
    }
}
