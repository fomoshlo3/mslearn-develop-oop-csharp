---
lab:
    title: 'Exercise - Manage class implementations'
    description: 'Learn how to improve code quality by creating static and partial classes, using optional parameters in constructors, and by implementing copy constructors and object initializers in your applications.'
---


# Manage class implementations

The term code quality refers to the overall readability, maintainability, efficiency, reusability, reliability, and testability of your code. By improving code quality, you can make your code easier to understand, modify, and extend. Object-oriented programming (OOP) provides several features that can help you improve code quality, such as static and partial classes, nested classes, optional and named parameters, copy constructors, and object initializers. These features can help you organize your code more effectively, reduce redundancy, and make your code more flexible and concise.

In this exercise, you improve an existing application's code quality by implementing static and partial classes, and by using optional parameters in class constructors. You also improve object management in your application code by implementing copy constructors and object initializers.

This exercise takes approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you need to:

1. Ensure that you have the latest LTS version of the .NET SDK installed on your computer. You can download the latest version of the .NET SDK from the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code from the following URL: [https://code.visualstudio.com/](https://code.visualstudio.com/)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For additional help configuring the Visual Studio Code environment, see [https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/](https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/)

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You've developed an initial version of the app that includes the following files:

- BankAccount.cs: The BankAccount class represents a bank account with properties for account number, customer ID, balance, and account type. It includes methods for depositing, withdrawing, transferring funds, applying interest, and displaying account information. It also maintains static properties for the next account number and interest rate.
- BankCustomer.cs: The BankCustomer class represents a bank customer with properties for first name, last name, and a unique customer ID. It includes methods to return the full name, update the customer's name, and display customer information. It also maintains a static property for the next customer ID.
- Extensions.cs: The Extensions.cs file contains extension methods for the BankCustomer and BankAccount classes. For BankCustomer, it includes methods to check if the customer ID is valid and to greet the customer. For BankAccount, it includes methods to check if the account is overdrawn and if a specified amount can be withdrawn.
- Program.cs: The Program.cs file demonstrates the creation and manipulation of BankCustomer and BankAccount objects. It includes steps to create customers and accounts, update customer names, and use various methods of the BankAccount class such as deposit, withdraw, transfer, and apply interest. It also demonstrates the use of extension methods and displays customer and account information.

This exercise includes the following tasks:

1. Review the current version of your banking app
1. Split the BankCustomer class into two partial class files
1. Create a static class for transactional BankAccount methods
1. Use optional parameters to improve constructor flexibility
1. Implement object initializers and copy constructors

## Review the current version of your banking app

In this task, you download the existing version of your banking app and review the code.

Use the following steps to complete this section of the exercise:

1. Download the starter code from the following URL: [Implement classes, properties, and methods - exercise code projects](https://github.com/MicrosoftLearning/mslearn-develop-oop-csharp/raw/refs/heads/main/DownloadableCodeProjects/Downloads/LP1SampleApps.zip)

1. Extract the contents of the LP1SampleApps.zip file to a folder location on your computer.

1. Expand the LP1SampleApps folder, and then open the `Classes_M3` folder.

    The Classes_M3 folder contains the following code project folders:

    - Solution
    - Starter

    The **Starter** folder contains the starter project files for this exercise.

1. Use Visual Studio Code to open the **Starter** folder.

1. In the EXPLORER view, collapse the **STARTER** folder, select **SOLUTION EXPLORER**, and expand the **Classes_M3** project.

    You should see the following project files:

    - BankAccount.cs
    - BankCustomer.cs
    - Extensions.cs
    - Program.cs

1. Open the BankAccount.cs file and take a minute to review the BankAccount class.

    The `BankAccount` class represents a bank account with properties and methods to manage account operations.

    Notice that the class includes static fields `s_nextAccountNumber` and `InterestRate`, which track the next account number and the interest rate applied to accounts, respectively. Each `BankAccount` instance has properties such as `AccountNumber`, `CustomerId`, `Balance`, and `AccountType`, with default values for balance and account type. The class includes constructors for initializing accounts with or without an initial balance and account type. Methods provided by the class include `Deposit` for adding funds, `Withdraw` for removing funds, `Transfer` for transferring funds between accounts, `ApplyInterest` for applying interest to the balance, and `DisplayAccountInfo` for displaying account details. The class also features a static constructor to initialize static fields.

    The `this` keyword is used to access the properties of the current class instance. For example, `this.AccountNumber` refers to the `AccountNumber` property of the current `BankAccount` instance.

1. Open the BankCustomer.cs file and take a minute to review the BankCustomer class.

    The BankCustomer class represents a bank customer with properties and methods to manage customer information.

    Notice that the class includes a static field `nextCustomerId` to track the next customer ID, and instance fields `FirstName` and `LastName` for storing the customer's first and last names, respectively. Each `BankCustomer` instance has a read-only `CustomerId` property, which is initialized using a static constructor that generates a random starting ID. The class provides properties `FirstName` and `LastName` for accessing and modifying the customer's name. Methods in the class include `ReturnFullName` to return the customer's full name, `UpdateName` to update the customer's name, and `DisplayCustomerInfo` to display customer details. The class also features a constructor for initializing a new customer with a first and last name.

1. Open the Extensions.cs file and take a minute to review the BankCustomerExtensions and BankAccountExtensions classes.

    The Extensions.cs file contains extension methods for the `BankCustomer` and `BankAccount` classes within the `Classes_M3` namespace. These extension methods enhance the functionality of the `BankCustomer` and `BankAccount` classes by adding useful operations without modifying the original class definitions.

    The `BankCustomerExtensions` static class provides a `IsValidCustomerId` method that validates a customer's ID (ensuring that it's 10 characters long) and a `GreetCustomer` method that returns a personalized greeting using the customer's full name.

    The `BankAccountExtensions` static class includes an `IsOverdrawn` methods that checks if an account is overdrawn (returning `true` if the balance is negative) and a `CanWithdraw` method that's used to verify whether a specified amount can be withdrawn from the account (ensuring the balance is sufficient for the withdrawal).

1. Open the Program.cs file and take a minute to review the demonstration code.

    The Program.cs file demonstrates the creation and manipulation of `BankCustomer` and `BankAccount` objects within the `Classes_M3` namespace.

    Top-level statements provide an implicit entry point for the app. The code instantiates `BankCustomer` objects with different names, followed by the creation of corresponding `BankAccount` objects with varying initial balances. The program showcases the use of properties and methods of these classes, such as updating customer names, depositing and withdrawing funds, transferring money between accounts, and applying interest. Additionally, it demonstrates the use of extension methods to greet customers, validate customer IDs, check if accounts are overdrawn, and verify if withdrawals can be made. Finally, the program displays customer and account information to the console.

1. Run the app and review the output in the terminal window.

    To run your app, right-click the **Classes_M3** project in the Solution Explorer, select **Debug**, and then select **Start New Instance**.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012396421
    BankCustomer 2: Lisa Shao 0012396422
    BankCustomer 3: Sandy Zoeng 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012396421
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Thomas Margand
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

    The customer IDs and account numbers in your output will be different from the example output. Remember that they're sequential values based on a randomly generated initial value.

    > [!TIP]
    > If you encounter any issues while completing this exercise, review the provided code snippets and compare them to your own code. Pay close attention to the syntax and structure of the code. If you're still having trouble, you can review the solution code in the sample apps that you downloaded at the beginning of this exercise. To view the Classes_M3 solution, navigate to the LP1SampleApps/Classes_M3/Solution folder and open the Solution project in Visual Studio Code.

## Split the BankCustomer class into two partial class files

Partial classes allow you to split the definition of a class across multiple files. This can be useful when a class has a large number of properties and methods, or when you want to separate the definition of a class into logical sections. Splitting a class between two partial class files can make your code easier to read and maintain. For example, if the methods of a class are logically grouped into different categories, you can place each group of methods in a separate partial class file. This enables a team of developers to work on different parts of a class without interfering with each other's work. By using partial classes, you can organize your code more effectively and improve the readability and maintainability of your code.

In this task, you split the BankAccount class between two partial class files, moving the methods into a separate file.

Use the following steps to complete this section of the exercise:

1. Create a new class file for a class named **BankCustomerMethods**.

    Your code file should look similar to the following code snippet:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class BankCustomerMethods
    {
    
    }

    ```

    You can use the `Classes_M3` project to create new class file named BankCustomerMethods. Right-click the **Classes_M3** project in the Solution Explorer, select **New File**, select **Class**, and then enter **BankCustomerMethods**.

1. Update the BankCustomerMethods.cs file to match the following code:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {

    }

    ```

    The `partial` keyword indicates that the `BankCustomer` class is defined in multiple files.

1. Open the BankCustomer.cs file.

1. Update the class definition to include the `partial` keyword.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {

        // existing code removed for brevity

    }

    ```

    The `BankCustomer` class is now split between the BankCustomer.cs and BankCustomerMethods.cs files.

1. Move the `ReturnFullName`, `UpdateName`, and `DisplayCustomerInfo` methods to the BankCustomerMethods.cs file.

1. Take a minute to review your updated code files.

    BankCustomerMethods.cs

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {
        // Method to return the full name of the customer
        public string FullName()
        {
            return $"{FirstName} {LastName}";
        }
    
        // Method to update the customer's name
        public void UpdateName(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    
        // Method to display customer information
        public string DisplayCustomerInfo()
        {
            return $"Customer ID: {CustomerId}, Name: {FullName()}";
        }
    }
    
    ```

    BankCustomer.cs

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {
        private static int nextCustomerId;
        private string _firstName = "Tim";
        private string _lastName = "Shao";
        public readonly string CustomerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.CustomerId = (nextCustomerId++).ToString("D10");
        }
    
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
    
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
    }

    ```

1. Run the app to ensure that your partial class updates didn't introduce any bugs.

    Splitting a class into two partial class files can improve code organization, but shouldn't affect the functionality of the app. The BankCustomer class should still work as expected, and you should see the same output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0012396421
    BankCustomer 2: Lisa Shao 0012396422
    BankCustomer 3: Sandy Zoeng 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0012396421
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Thomas Margand
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

## Create a static class for transactional BankAccount methods

Static classes are used to organize methods that don't require an instance of a class to be created. Static classes can't be instantiated, and their methods can be called directly without creating an instance of the class. Static classes are useful for grouping related methods together and providing a convenient way to access them. In this task, you create a static class named Transactions that holds methods for the BankAccount class. The Transactions class includes methods for depositing, withdrawing, transferring funds, and applying interest to a bank account.

Use the following steps to complete this section of the exercise:

1. Create a new file in the `Classes_M3` project for a class named **Transactions**.

    Your Transactions.cs file should look similar to the following code:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class Transactions
    {

    }

    ```

1. Add the `static` keyword to the class definition to make it a static class.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public static class Transactions
    {

    }

    ```

1. Open the BankAccount.cs file.

1. Move the `Deposit`, `Withdraw`, `Transfer`, and `ApplyInterest` methods from the `BankAccount` class to the `Transactions` class.

    Your updated Transactions.cs file should look like this:

    ```csharp

    public static class Transactions
    {
        // Method to deposit money into the account
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }
    
        // Method to withdraw money from the account
        public bool Withdraw(double amount)
        {
            if (amount > 0 && Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    
        // Method to transfer money to another account
        public bool Transfer(BankAccount targetAccount, double amount)
        {
            if (Withdraw(amount))
            {
                targetAccount.Deposit(amount);
                return true;
            }
            return false;
        }
    
        // Method to apply interest to the account
        public void ApplyInterest()
        {
            Balance += Balance * InterestRate;
        }

    }

    ```

1. Notice that the Visual Studio Code environment uses red squiggly lines to indicate errors in your code.

    There are two issues that you need to address:

    - The methods in a static class must be static, so you need to update the method signatures to include the `static` keyword.
    - The properties and fields defined by the `BankAccount` class are not directly accessible in the `Transactions` class. You need to update the method signatures to accept a `BankAccount` parameter and use the `BankAccount` instance to access properties within the static methods.

1. Take a moment to consider the `Deposit` method.

    ```csharp

    // Method to deposit money into the account
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    ```

    The `Deposit` method came from the `BankAccount` class, where it could access the `Balance` property directly. However, the `Balance` property is no longer available in the `Transactions` class. To update the `Deposit` method, you need to update the method signature to accept a `BankAccount` parameter, and then use the `BankAccount` instance to access the `Balance` property.

1. To include a `BankAccount` parameter to the signature and then reference the account object within the method, update the `Deposit` method to match the following code snippet:

    ```csharp

    // Method to deposit money into the account
    public static void Deposit(BankAccount account, double amount)
    {
        if (amount > 0)
        {
            account.Balance += amount;
        }
    }
    
    ```

    Notice that the `Deposit` method now accepts a `BankAccount` parameter named `account`, and that it uses the `account` object to access the `Balance` property. The `account.Balance` property is updated using `amount` parameter.

1. Notice that `account.Balance` can't be modified from the static method because the setter is private.

    To update the `Balance` property, you need to add an `internal` method to the `BankAccount` class that enabled classes within the assembly to modify the `Balance` property. This keeps the `Balance` property encapsulated within the `BankAccount` class while allowing the `Transactions` class to update the `Balance` property.

1. Add the following `SetBalance` method to the `BankAccount` class:

    ```csharp

    internal void SetBalance(double balance)
    {
        Balance = balance;
    }

    ```

1. To use the `SetBalance` method in the `Transactions` class, update the `Deposit` method using the following code:

    ```csharp

    // Method to deposit money into the account
    public static void Deposit(BankAccount account, double amount)
    {
        if (amount > 0)
        {
            account.SetBalance(account.Balance + amount);
        }
    }

    ```

1. Repeat the process used to update `Deposit` to correct the issues in the remaining `Transactions` class methods.

    Ensure that each of the Transaction methods accepts a `BankAccount` parameter and uses the `BankAccount` instance to access the required properties and fields.

    > [!IMPORTANT]
    > Remember that static fields are accessed using the class name, not an instance of the class. For example, to access the `InterestRate` field, you use `BankAccount.InterestRate`. Also, keep in mind that the `Transfer` method uses the updates `Deposit` and `Withdraw` methods in the `Transactions` class, not the old methods from the `BankAccount` class. Ensure that you update the `Withdraw` and `Deposit` method signatures within the `Transfer` method to accept `BankAccount` and `amount` parameters. For example, the `Withdraw` method should be updated to `Withdraw(sourceAccount, amount)` and the `Deposit` method should be updated to `Deposit(targetAccount, amount)`.

1. Take a minute to review your updated Transactions class.

    Your updated Transactions class should look similar to the following code snippet:

    ```csharp

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
            account.Balance += account.Balance * BankAccount.InterestRate;
        }
    }

    ```

1. Open the Program.cs file.

1. Locate the code that demonstrates the use of BankAccount methods.

    ```csharp

    // Step 4: Demonstrate the use of BankAccount methods
    Console.WriteLine("\nDemonstrating BankAccount methods...");
    
    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    account1.Deposit(500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");
    
    // Withdraw
    Console.WriteLine("Withdrawing 200 from Account 2...");
    bool withdrawSuccess = account2.Withdraw(200);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");
    
    // Transfer
    Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
    bool transferSuccess = account3.Transfer(account1, 300);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");
    
    // Apply interest
    Console.WriteLine("Applying interest to Account 1...");
    account1.ApplyInterest();
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");

    ```

1. Notice that the code in the Program.cs file uses `BankAccount` objects to access the `Deposit`, `Withdraw`, `Transfer`, and `ApplyInterest` methods.

    For example:

    ```csharp

    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    account1.Deposit(500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");

    ```

1. To use the `Transactions.Deposit()` static method for the deposit into `account1`, update your code to match the following code snippet:

    ```csharp

    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    Transactions.Deposit(account1, 500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");

    ```

1. Use the same approach to implement the `Withdraw`, `Transfer`, and `ApplyInterest` methods.

    For the `Transfer` method, the account used to access the old method becomes the first parameter in the new method. The account that was passed as a parameter to the old method becomes the second parameter in the new method. The amount parameter remains as the final parameter.

1. Ensure that your code uses the `Transactions` class for all transactional methods in the Program.cs file.

    Your updated Program.cs file should look similar to the following code snippet:

    ```csharp

    // code removed for brevity

    // Step 4: Demonstrate the use of BankAccount methods
    Console.WriteLine("\nDemonstrating BankAccount methods...");
    
    // Deposit
    Console.WriteLine("Depositing 500 into Account 1...");
    Transactions.Deposit(account1, 500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");
    
    // Withdraw
    Console.WriteLine("Withdrawing 200 from Account 2...");
    bool withdrawSuccess = Transactions.Withdraw(account2, 200);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");
    
    // Transfer
    Console.WriteLine("Transferring 300 from Account 3 to Account 1...");
    bool transferSuccess = Transactions.Transfer(account3, account1, 300);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");
    
    // Apply interest
    Console.WriteLine("Applying interest to Account 1...");
    Transactions.ApplyInterest(account1);
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");

    // code removed for brevity

    ```

1. Run the app to ensure that your static class updates didn't introduce any bugs.

    By moving the transactional methods to a static class, you can organize your code more effectively and improve the readability and maintainability of your code. The BankAccount class should still work as expected, and you should see the same output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0016320839
    BankCustomer 2: Lisa Shao 0016320840
    BankCustomer 3: Sandy Zoeng 0016320841
    
    Creating BankAccount objects for customers...
    Account 1: Account # 12848501, type Checking, balance 0, rate 0, customer ID 0016320839
    Account 2: Account # 12848502, type Checking, balance 1500, rate 0, customer ID 0016320840
    Account 3: Account # 12848503, type Checking, balance 2500, rate 0, customer ID 0016320841
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0016320839
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0016320839, Name: Thomas Margand
    Account Number: 12848501, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0016320839

    ```

## Use optional parameters to improve constructor flexibility

Using named and optional parameters can improve code readability and flexibility, especially in constructors and methods with multiple parameters. In this workspace, the files that would benefit the most from named and optional parameters are BankAccount.cs and Transactions.cs.

In this task, you update a constructor in the BankAccount class using optional parameters.

1. Open the BankAccount.cs file and locate the class constructors.

    ```csharp
    
    static BankAccount()
    {
        Random random = new Random();
        s_nextAccountNumber = random.Next(10000000, 20000000);
        InterestRate = 0;
    }
    
    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }
    
    public BankAccount(string customerIdNumber, double balance, string accountType)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
    
    ```

    The constructors in the BankAccount class can be improved by using optional parameters to provide default values, reducing the need for multiple constructor overloads.

1. Replace the two instance constructors with the following constructor that uses optional parameters:

    ```csharp
    
    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
    
    ```

    By using optional parameters in the BankAccount constructor, you can create instances of `BankAccount` with varying levels of parameter detail, making class instantiation more flexible and reducing the need for multiple constructor overloads. For example, you can create a `BankAccount` object with only a `customerIdNumber`, or you can specify combinations of `Balance` and `accountType` as well:

    ```csharp

    BankAccount account1 = new BankAccount("1234567890");
    BankAccount account2 = new BankAccount("2345678901", 1500);
    BankAccount account3 = new BankAccount("3456789012", 2500, "Checking");
    BankAccount account4 = new BankAccount("4567890123", accountType: "Checking");
    BankAccount account5 = new BankAccount("5678901234", accountType: "Checking", balance: 5000);
        
    ```

    > [!NOTE]
    > Optional parameters can make your code more flexible and easier to read. In this case, there are no changes required to the code in your Program.cs. In fact, new constructor enables you to create BankAccount objects with parameter combinations that were not possible before.

1. Take a minute to review your BankAccount.cs code.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public class BankAccount
    {
        private static int s_nextAccountNumber;
        public static double InterestRate;
        public int AccountNumber { get; }
        public string CustomerId { get; }
        public double Balance { get; private set; } = 0;
        public string AccountType { get; set; } = "Checking";
    
        static BankAccount()
        {
            Random random = new Random();
            s_nextAccountNumber = random.Next(10000000, 20000000);
            InterestRate = 0;
        }
    
        public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
        {
            this.AccountNumber = s_nextAccountNumber++;
            this.CustomerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    
        // Method to display account information
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {InterestRate}, Customer ID: {CustomerId}";
        }
    
    }

    ```

1. Run the app to ensure that your optional parameter updates didn't introduce any bugs.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0016320839
    BankCustomer 2: Lisa Shao 0016320840
    BankCustomer 3: Sandy Zoeng 0016320841
    
    Creating BankAccount objects for customers...
    Account 1: Account # 12848501, type Checking, balance 0, rate 0, customer ID 0016320839
    Account 2: Account # 12848502, type Checking, balance 1500, rate 0, customer ID 0016320840
    Account 3: Account # 12848503, type Checking, balance 2500, rate 0, customer ID 0016320841
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0016320839
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0016320839, Name: Thomas Margand
    Account Number: 12848501, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0016320839

    ```

## Implement copy constructors and object initializers

Object initializers and copy constructors are useful techniques for creating and copying objects in C#. Both techniques can enhance code readability and maintainability.

- Copy constructors allow you to create a new object that's a copy of an existing object. This is useful when you need to duplicate objects with the same state.
- Object initializers allow you to initialize an object and set its properties in a single statement. This can make the code more concise and readable.

In this task, you implement copy constructors and object initializers by updating constructors in the `BankCustomer` and `BankAccount` classes, and the demonstration code in Program.cs.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. To create a copy constructor for the BankCustomer class, add the following code:

    ```csharp

    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {

        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        //this.CustomerId = existingCustomer.CustomerId;
        this.CustomerId = (nextCustomerId++).ToString("D10");

    }

    ```

    Notice that the `CustomerId` field from the existing customer isn't used. Instead, a new `CustomerId` is generated for the new customer. This supports the logic already implemented by the BankCustomer class.

1. Open the BankAccount.cs file.

1. To create a copy constructor for the BankAccount class, add the following code:

    ```csharp

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = s_nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    ```

    Notice that a new `AccountNumber` field is generated for the new account. The `CustomerId`, `Balance`, and `AccountType` fields are copied from the existing account. The `InterestRate` field is not copied because it's a static field that's shared across all instances of the BankAccount class. The `CustomerId` field is copied because the intension is to create a new account for the same customer.

1. Open the Program.cs file.

1. Add the following Step 7 code to the end of the Program.cs file

    ```csharp

    // Step 7: Demonstrate using object initializers and copy constructors
    Console.WriteLine("\nDemonstrating object initializers and copy constructors...");
    
    // Using object initializer
    BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
    Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.CustomerId}");
    
    // Using copy constructor
    BankCustomer customer5 = new BankCustomer(customer4);
    Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.CustomerId}");
    
    BankAccount account4 = new BankAccount(customer4.CustomerId, 3000, "Savings");
    BankAccount account5 = new BankAccount(account4);
    Console.WriteLine($"Account 4: Account # {account4.AccountNumber}, type {account4.AccountType}, balance {account4.Balance}, rate {BankAccount.InterestRate}, customer ID {account4.CustomerId}");
    Console.WriteLine($"Account 5 (copy of account4): Account # {account5.AccountNumber}, type {account5.AccountType}, balance {account5.Balance}, rate {BankAccount.InterestRate}, customer ID {account5.CustomerId}");

    ```

    Notice the following:

    - The `customer4` object is created using an object initializer. The `FirstName` and `LastName` properties are set using the object initializer syntax.
    - The `customer5` object is created using a copy constructor. The `customer5` object is a copy of the `customer4` object.
    - The `account4` object is created using an object initializer. The `Balance` and `AccountType` properties are set using the object initializer syntax.
    - The `account5` object is created using a copy constructor. The `account5` object is a copy of the `account4` object.

1. Run the app and review the output in the terminal window.

    Your app should produce output that's similar to the following example:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: Tim Shao 0011223008
    BankCustomer 2: Lisa Shao 0011223009
    BankCustomer 3: Sandy Zoeng 0011223010
    
    Creating BankAccount objects for customers...
    Account 1: Account # 12475143, type Checking, balance 0, rate 0, customer ID 0011223008
    Account 2: Account # 12475144, type Checking, balance 1500, rate 0, customer ID 0011223009
    Account 3: Account # 12475145, type Checking, balance 2500, rate 0, customer ID 0011223010
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Thomas Margand 0011223008
    
    Demonstrating BankAccount methods...
    Depositing 500 into Account 1...
    Account 1 after deposit: Balance = 500
    Withdrawing 200 from Account 2...
    Account 2 after withdrawal: Balance = 1300, Withdrawal successful: True
    Transferring 300 from Account 3 to Account 1...
    Account 3 after transfer: Balance = 2200, Transfer successful: True
    Account 1 after receiving transfer: Balance = 800
    Applying interest to Account 1...
    Account 1 after applying interest: Balance = 800
    
    Demonstrating extension methods...
    Hello, Thomas Margand!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0011223008, Name: Thomas Margand
    Account Number: 12475143, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0011223008
    
    Demonstrating object initializers and copy constructors...
    BankCustomer 4: Mikaela Lee 0011223011
    BankCustomer 5 (copy of customer4): Mikaela Lee 0011223012
    Account 4: Account # 12475146, type Savings, balance 3000, rate 0, customer ID 0011223011
    Account 5 (copy of account4): Account # 12475147, type Savings, balance 3000, rate 0, customer ID 0011223011

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
