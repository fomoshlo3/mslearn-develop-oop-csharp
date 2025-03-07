using Data_M2;
using System.Globalization;
using System.Collections.ObjectModel;

class Program
{
    static void Main(string[] args)
    {
        // Task 1: Review starter code

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 2: Create a Bank class that includes a collection of BankCustomer objects

        // Step 1: Add a new class file named Bank to the Data_M2 project
        // Step 2: Add constructors, properties, and methods to the Bank class definition 
        //  - Include a read-only Customers property that provides access to a collection of BankCustomer objects (IReadOnlyList<BankCustomer> Customers)
        //  - Include a method that adds a BankCustomer object to the collection
        //  - Include a method that removes a BankCustomer object from the collection
        //  - Include a method that returns a collection containing all BankCustomer objects
        //  - Include a method that returns a BankCustomer objects based on customer name
        //  - Include a method that returns the total number of transactions
        //  - Include a method that returns the total amount of money in the bank vault
        //  - Include a method that returns the total of all deposits for the day
        //  - Include a method that returns the total of all withdrawals for the day


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 3: Update the BankCustomer class to include a collection of BankAccount objects
        //  - Add a read-only Accounts property that provides access to a collection of BankAccount objects (IReadOnlyList<BankAccount> Accounts)
        //  - Add a method that adds a BankAccount object to the collection
        //  - Add a method that removes a BankAccount object from the collection
        //  - Add a method that returns a collection containing all BankAccount objects
        //  - Add a method that returns a collection containing all BankAccount objects of a specific account type


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 4: Update the BankAccount class to include a collection of Transaction objects
        //  - Add a read-only Transactions property that provides access to a collection of Transaction objects (IReadOnlyList<Transaction> Transactions)
        //  - Add a method that adds a Transaction object to the collection
        //  - Add a method that removes a Transaction object from the collection
        //  - Add a method that returns a collection containing all Transaction objects


        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 5: Create collections of BankCustomer and BankAccount objects

        Console.WriteLine($"Creating Bank, BankCustomer, and BankAccount objects...");

        // Step 1: Create a Bank object
        Bank bank = new Bank();
        Console.WriteLine($"\nBank object created...");

        // Step 2: Add a BankCustomer object to the Bank object
        BankCustomer customer1 = new BankCustomer("Tim", "Shao");
        bank.AddCustomer(customer1);
        Console.WriteLine($"Bank customer {customer1.ReturnFullName()} created and added to the Bank object's customer collection...");

        // Step 3: Add Checking and Savings accounts to the bank customer
        double openingBalanceChecking = 5000.00;
        double openingBalanceSavings = 20000.00;
        BankAccount account1 = new CheckingAccount(customer1, customer1.CustomerId, openingBalanceChecking);
        BankAccount account2 = new SavingsAccount(customer1, customer1.CustomerId, openingBalanceSavings);
        customer1.AddAccount(account1);
        customer1.AddAccount(account2);
        Console.WriteLine($"{customer1.Accounts[0].AccountType} and {customer1.Accounts[1].AccountType} account objects created and added to {customer1.ReturnFullName()}'s account collection...");

        Console.WriteLine($"\nIs {customer1.ReturnFullName()} a premium customer: {customer1.IsPremiumCustomer()}");
        // Display accounts
        Console.WriteLine("Account details:");
        foreach (var account in customer1.Accounts)
        {
            Console.WriteLine($"  - {account.DisplayAccountInfo()}");
        }

        // Step 4: Add a MoneyMarket account to the bank customer and promote the customer to premium customer
        double openingBalanceMoneyMarket = 90000.00;
        Console.WriteLine($"\nOpen a MoneyMarket account for {customer1.ReturnFullName()} with a {openingBalanceMoneyMarket:C} balance and check premium status...");
        BankAccount account3 = new MoneyMarketAccount(customer1, customer1.CustomerId, openingBalanceMoneyMarket);
        customer1.AddAccount(account3);

        Console.WriteLine($"Is {customer1.ReturnFullName()} a premium customer: {customer1.IsPremiumCustomer()}");
        // Display accounts
        Console.WriteLine("Account details:");
        foreach (var account in customer1.Accounts)
        {
            Console.WriteLine($"  - {account.DisplayAccountInfo()}");
        }

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 6: Create a collection of Transaction objects

        // Generate transactions for the past two years based on current date
        Console.WriteLine("\nGenerating two years of prior transactions based on current date...");
        DateOnly currentDate = DateOnly.FromDateTime(DateTime.Now);

        DateOnly startDate2Years = currentDate.AddYears(-2);
        DateOnly endDate2Years = currentDate;
        //customer1 = SimulateCustomerAccountActivity.SimulateActivityDateRange(startDate2Years, endDate2Years, customer1);
        customer1 = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDate2Years, endDate2Years, customer1);

        // Generate transactions for the previous month only
        // Console.WriteLine("\nGenerating transactions for the previous month...");
        // get the first and last day of the previous month
        // DateOnly previousMonth = currentDate.AddMonths(-1);
        // DateOnly startDatePreviousMonth = new DateOnly(previousMonth.Year, previousMonth.Month, 1);
        // DateOnly endDatePreviousMonth = new DateOnly(previousMonth.Year, previousMonth.Month, DateTime.DaysInMonth(previousMonth.Year, previousMonth.Month));

        // customer1 = SimulateDepositsWithdrawalsTransfers.SimulateActivityDateRange(startDatePreviousMonth, endDatePreviousMonth, customer1);

        // ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        // Task 7: Create reports for BankCustomer and BankAccount objects

        // Call the AccountReportGenerator class to generate reports


        foreach (BankCustomer bankCustomer in bank.Customers)
        {
            if (bankCustomer.ReturnFullName() == customer1.ReturnFullName())
            {
                foreach (BankAccount account in bankCustomer.Accounts)
                {
                    if (account.AccountType == "Checking")
                    {
                        Console.WriteLine($"\nGenerating reports for {bankCustomer.ReturnFullName()}'s {account.AccountType} account...");

                        DateOnly reportDate = currentDate.AddMonths(-1);
                        AccountReportGenerator accountReports = new AccountReportGenerator(account);

                        accountReports.GenerateMonthlyReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GenerateCurrentMonthToDateReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GeneratePrevious30DayReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GenerateQuarterlyReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GeneratePreviousYearReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GenerateCurrentYearToDateReport(bankCustomer, account.AccountNumber, reportDate);
                        accountReports.GenerateLast365DaysReport(bankCustomer, account.AccountNumber, reportDate);

                        // Call the CustomerReportGenerator class to generate reports
                        Console.WriteLine("\nGenerating reports for a BankCustomer object...");
                        CustomerReportGenerator customerReportGenerator = new CustomerReportGenerator(bankCustomer);
                        customerReportGenerator.GenerateMonthlyReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GenerateCurrentMonthToDateReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GeneratePrevious30DayReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GenerateQuarterlyReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GeneratePreviousYearReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GenerateCurrentYearToDateReport(bankCustomer, account.AccountNumber, reportDate);
                        customerReportGenerator.GenerateLast365DaysReport(bankCustomer, account.AccountNumber, reportDate);

                    }
                }
            }
        }
    }
}
