---
lab:
    title: 'Exercise - Implement polymorphism in a C# app'
    description: 'Learn the principles of polymorphism and how to implement polymorphic behavior in C# apps using interface-based and inheritance-based approaches.'
---

# Implement polymorphism in a C# app

Polymorphism is a fundamental concept in object-oriented programming that allows you to treat derived classes as instances of their base class. In C#, you can implement polymorphic behavior using interface implementation and class inheritance.

In this exercise, you update an existing app to demonstrate interface-based and inheritance-based polymorphic behavior.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest short term support (STS) version of the .NET SDK installed on your computer. You can download the latest versions of the .NET SDK using the following URL: <a href="https://dotnet.microsoft.com/download/" target="_blank">Download .NET</a>

1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code using the following URL: <a href="https://code.visualstudio.com/download/" target="_blank">Download Visual Studio Code</a>

1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see <a href="https://learn.microsoft.com/training/modules/install-configure-visual-studio-code/" target="_blank">Install and configure Visual Studio Code for C# development</a>

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a banking app. You've developed an initial version of the app that includes the following files:

- AccountCalculations.cs: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

- BankAccount.cs: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

- BankCustomer.cs: This file defines the BankCustomer class, with properties for first name, last name, and a unique customer ID. It includes methods to return the full name, update the customer's name, and display customer information. It also maintains a static property for the next customer ID.

- BankCustomerMethods.cs: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

- CheckingAccount.cs: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts, such as an overdraft limit.

- Extensions.cs: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting. For BankCustomer, it includes methods to check if the customer ID is valid and to greet the customer. For BankAccount, it includes methods to check if the account is overdrawn and if a specified amount can be withdrawn.

- IBankAccount.cs: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

- IBankCustomer.cs: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

- MoneyMarketAccount.cs: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts, such as a minimum balance requirement.

- Program.cs: This file contains the main entry point of the application, demonstrating the creation and manipulation of objects created using base and derived classes, as well as various operations like deposits, withdrawals, and transfers.

- SavingsAccount.cs: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts, such as a withdrawal limit.

This exercise includes the following tasks:

1. Review the current version of your banking app.

1. Create interfaces that support monthly, quarterly, and yearly reporting.

1. Create classes that support customer and account reporting.

1. Implement polymorphic behavior using interface implementation.

1. Implement polymorphic behavior using class inheritance.

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement classes, properties, and methods - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP3SampleApps.zip)

1. Extract the contents of the LP3SampleApps.zip file to a folder location on your computer.

1. Expand the LP3SampleApps folder, and then open the `Reuse_M2` folder.

    The Reuse_M1 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Reuse_M2** project.

    You should see the following project files:

    - AccountCalculations.cs
    - BankAccount.cs
    - BankCustomer.cs
    - BankCustomerMethods.cs
    - CheckingAccount.cs
    - Extensions.cs
    - IBankAccount.cs
    - IBankCustomer.cs
    - MoneyMarketAccount.cs
    - Program.cs
    - SavingsAccount.cs

1. Take a few minutes to open and review each of the files.

    - `AccountCalculations.cs`: This file contains static utility methods for various financial calculations, such as compound interest, transaction fees, overdraft fees, and currency exchange.

    - `BankAccount.cs`: This file defines the BankAccount class, implementing the IBankAccount interface and including properties, constructors, methods for account operations, and a copy constructor.

    - `BankCustomer.cs`: This file defines the BankCustomer class, implementing the IBankCustomer interface and including properties, constructors, and a copy constructor.

    - `BankCustomerMethods.cs`: This file implements the methods defined in the IBankCustomer interface for the BankCustomer class, including methods to return full name, update name, and display customer information.

    - `CheckingAccount.cs`: This file defines the CheckingAccount class, which inherits from the BankAccount class and includes properties and methods specific to checking accounts.

    - `Extensions.cs`: This file contains extension methods for IBankCustomer and IBankAccount interfaces, providing additional functionality such as validation and greeting.

    - `IBankAccount.cs`: This file defines the IBankAccount interface, specifying the properties and methods that a bank account class must implement.

    - `IBankCustomer.cs`: This file defines the IBankCustomer interface, specifying the properties and methods that a bank customer class must implement.

    - `MoneyMarketAccount.cs`: This file defines the MoneyMarketAccount class, which inherits from the BankAccount class and includes properties and methods specific to money market accounts.

    - `Program.cs`: This file contains the main entry point of the application, demonstrating the creation and manipulation of BankCustomer and BankAccount objects, as well as various operations like deposits, withdrawals, and transfers.

    - `SavingsAccount.cs`: This file defines the SavingsAccount class, which inherits from the BankAccount class and includes properties and methods specific to savings accounts.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Reuse_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    Creating BankAccount objects for customer1...
    Account Number: 19395527, Type: Checking, Balance: 500, Interest Rate: 0, Customer ID: 0019912501, Overdraft Limit: 400
    Account Number: 19395528, Type: Savings, Balance: 1000, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 0
    Account Number: 19395529, Type: Money Market, Balance: 2000, Interest Rate: 0.04, Customer ID: 0019912501, Minimum Balance: 1000, Interest Rate: 4%, Minimum Opening Balance: 2000
    Account Number: 19395530, Type: Certificate of Deposit, Balance: 5000, Interest Rate: 0.05, Customer ID: 0019912501, Maturity Date: 9/6/2025, Early Withdrawal Penalty: 10%, Interest Rate: 5%
    
    Demonstrating specialized Withdraw behavior:
    
    CheckingAccount: Attempting to withdraw $600 (within overdraft limit)...
    Overdraft fee of $5 applied.
    Account Number: 19395527, Type: Checking, Balance: -105, Interest Rate: 0, Customer ID: 0019912501, Overdraft Limit: 400
    
    CheckingAccount: Attempting to withdraw $1000 (exceeding overdraft limit)...
    Account Number: 19395527, Type: Checking, Balance: -105, Interest Rate: 0, Customer ID: 0019912501, Overdraft Limit: 400
    
    SavingsAccount: Attempting to withdraw $200 (within withdrawal limit)...
    Account Number: 19395528, Type: Savings, Balance: 800, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 1
    
    SavingsAccount: Attempting to withdraw $900 (exceeding withdrawal limit)...
    Account Number: 19395528, Type: Savings, Balance: 800, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 1
    
    SavingsAccount: Exceeding maximum number of withdrawals per month...
    Attempting to withdraw $50 (withdrawal 1)...
    Account Number: 19395528, Type: Savings, Balance: 750, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 2
    Attempting to withdraw $50 (withdrawal 2)...
    Account Number: 19395528, Type: Savings, Balance: 700, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 3
    Attempting to withdraw $50 (withdrawal 3)...
    Account Number: 19395528, Type: Savings, Balance: 650, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 4
    Attempting to withdraw $50 (withdrawal 4)...
    Account Number: 19395528, Type: Savings, Balance: 600, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 5
    Attempting to withdraw $50 (withdrawal 5)...
    Account Number: 19395528, Type: Savings, Balance: 550, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 6)...
    Account Number: 19395528, Type: Savings, Balance: 550, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 6
    Attempting to withdraw $50 (withdrawal 7)...
    Account Number: 19395528, Type: Savings, Balance: 550, Interest Rate: 0.02, Customer ID: 0019912501, Withdrawal Limit: 6, Withdrawals This Month: 6
    
    MoneyMarketAccount: Attempting to withdraw $1000 (maintaining minimum balance)...
    Account Number: 19395529, Type: Money Market, Balance: 1000, Interest Rate: 0.04, Customer ID: 0019912501, Minimum Balance: 1000, Interest Rate: 4%, Minimum Opening Balance: 2000
    
    MoneyMarketAccount: Attempting to withdraw $1900 (exceeding minimum balance)...
    Account Number: 19395529, Type: Money Market, Balance: 1000, Interest Rate: 0.04, Customer ID: 0019912501, Minimum Balance: 1000, Interest Rate: 4%, Minimum Opening Balance: 2000

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

    > [!TIP]
    > If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Classes_M3 solution, navigate to the LP1SampleApps/Classes_M3/Solution folder and open the Solution project in Visual Studio Code.

## Create interfaces that support monthly, quarterly, and yearly reporting

You want to add reporting capabilities to your banking app. You want monthly, quarterly, and yearly reporting periods for both customers and accounts. To achieve this, you'll create interfaces that define support the reporting periods. Once the interfaces are available, you can work on report generator classes for customers and accounts that implement the interfaces.

In this task, you create interfaces that support the following monthly, quarterly, and yearly reporting periods:

- IMonthlyReportable: This interface defines methods for generating reports that cover a full month, a partial month, and a 30 day period.
- IQuarterlyReportable: This interface defines a method for generating a report that covers three month period.
- IYearlyReportable: This interface defines methods for generating reports that cover a full year, a partial year, and a 365 day period.

Use the following steps to complete this section of the exercise:

1. Create a new file named `IMonthlyReportGenerator.cs`.

1. Update the `IMonthlyReportGenerator.cs` file with the following code:

    ```csharp
    public interface IMonthlyReportGenerator
    {


    }
    ```

1. Create a new file named `IQuarterlyReportGenerator.cs`.

1. Update the `IQuarterlyReportGenerator.cs` file with the following code:

    ```csharp
    public interface IQuarterlyReportGenerator
    {


    }
    ```

1. Create a new file named `IYearlyReportGenerator.cs`.

1. Update the `IYearlyReportGenerator.cs` file with the following code:

    ```csharp
    public interface IYearlyReportGenerator
    {


    }
    ```

## Create classes that support customer and account reporting

The IMonthlyReportGenerator, IQuarterlyReportGenerator, and IYearlyReportGenerator interfaces define the methods that you'll use to generate reports for customers and accounts. Now you need to create classes that implement these interfaces to support the reporting periods.

Use the following steps to complete this section of the exercise:

1. Create a new file named `CustomerReportGenerator.cs`.

1. Update the `CustomerReportGenerator.cs` file with the following code:

    ```csharp
    public class CustomerReportGenerator
    {


    }
    ```

1. Create a new file named `AccountReportGenerator.cs`.

1. Update the `AccountReportGenerator.cs` file with the following code:

    ```csharp
    public class AccountReportGenerator
    {


    }
    ```

## Implement polymorphic behavior using interface implementation

Interface-based polymorphism allows you to treat objects of different classes as instances of a common interface. In this task, you'll demonstrate polymorphic behavior using the reporting classes in the Program.cs file.

Use the following steps to complete this section of the exercise:

1. Open the Program.cs file.

1. Update the Program.cs file with the following code:

    ```csharp

    using Reuse_M2;
    using System.Globalization;
    
    class Program
    {
        static void Main(string[] args)
        {
    
        }
    }

    ```

1. To demonstrate interface-based polymorphic behavior, add the following code to the end of the `Main` method.

    ```csharp

    // Use interfaces to create instances of derived classes
    Console.WriteLine("Use interfaces to create instances of derived classes:");

    // Create instances of BankCustomer and BankAccount using interfaces
    firstName = "Sandy";
    lastName = "Zoeng";
    IBankCustomer customer1 = new StandardCustomer(firstName, lastName);
    IBankAccount account1 = new BankAccount(customer1.CustomerId, 10000);
    IBankAccount account2 = new CheckingAccount(customer1.CustomerId, 500, 400);
    IBankAccount account3 = new SavingsAccount(customer1.CustomerId, 1000);

    Console.WriteLine(account1.DisplayAccountInfo());
    Console.WriteLine(account2.DisplayAccountInfo());
    Console.WriteLine(account3.DisplayAccountInfo());

    // Demonstrate polymorphism based on interfaces
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

    ```

1. Run the app and verify that your reports are generated correctly.

    To run your app, right-click the **Reuse_M1** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext



    ```

## Implement polymorphic behavior using class inheritance

Inheritance-based polymorphism allows you to treat derived classes as instances of their base class. In this task, you'll demonstrate inheritance-based polymorphic behavior using the base and derived account classes.

Use the following steps to complete this section of the exercise:

1. Open the CheckingAccount.cs file.

1. Take a minute to review the CheckingAccount class.

1. Open the SavingsAccount.cs file.

1. Take a minute to review the SavingsAccount class.

1. Open the MoneyMarketAccount.cs file.

1. Take a minute to review the MoneyMarketAccount class.

1. Open the Program.cs file.

1. To demonstrate class-based polymorphic behavior, add the following code to the end of the `Main` method.

    ```csharp

    // Create a new customer and accounts for inheritance-based polymorphism
    Console.WriteLine("Creating BankCustomer and BankAccount objects...");
    string firstName = "Tim";
    string lastName = "Shao";
    BankCustomer customer2 = new PremiumCustomer(firstName, lastName);

    // Create accounts for customer1
    Console.WriteLine("Creating BankAccount objects for customer1...");
    BankAccount bankAccount1 = new BankAccount(customer2.CustomerId, 10000);
    BankAccount bankAccount2 = new CheckingAccount(customer2.CustomerId, 500, 400);
    BankAccount bankAccount3 = new SavingsAccount(customer2.CustomerId, 1000);
    BankAccount bankAccount4 = new MoneyMarketAccount(customer2.CustomerId, 2000);

    // Demonstrate polymorphism by accessing overridden methods from the base class reference
    Console.WriteLine("\nDemonstrating polymorphism by accessing overridden methods from the base class reference:");

    Console.WriteLine(bankAccount1.DisplayAccountInfo());
    Console.WriteLine(bankAccount2.DisplayAccountInfo());
    Console.WriteLine(bankAccount3.DisplayAccountInfo());
    Console.WriteLine(bankAccount4.DisplayAccountInfo());

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

    ```

1. Run the app and verify that your reports are generated correctly.

    ```plaintext



    ```
