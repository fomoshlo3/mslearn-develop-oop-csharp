---
lab:
    title: 'Exercise - Manage class implementations'
    description: 'Learn how to implement classes using advanced techniques like static classes, partial classes, and object initializers that can improve the readability, maintainability, and organization of your code.'
---


# Implement classes in C# applications

Class implementation affects the readability, maintainability, and organization of your code. Implementation techniques such as static classes, partial classes, and object initializers can improve your code. In this exercise, you update an existing code project by developing properties and methods.

In this exercise, you update an existing code project by developing properties and methods.

This exercise takes approximately **35** minutes to complete.

## Before you start

Before you can start this exercise, you will need to...

1. Ensure that you have the latest LTS version of the .NET SDK installed on your computer. You can download the latest version of the .NET SDK from the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code from the following URL: [https://code.visualstudio.com/](https://code.visualstudio.com/)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For addition help configuring the Visual Studio Code environment, see [https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/](https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/)

## Exercise scenario

Suppose you're helping a non-profit company with a software project. You've decided to sharpen your object-oriented programming skills by creating a simple banking app. You have an initial version of the app that includes the following files:

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

    You should see the following project files:

    - BankAccount.cs
    - BankCustomer.cs
    - Classes_M3.csproj
    - Extensions.cs
    - Program.cs

1. Open the BankAccount.cs file and take a minute to review the BankAccount class.

    Notice that ...

1. Open the BankCustomer.cs file and take a minute to review the BankCustomer class.

    Notice that ...

1. Open the Extensions.cs file and take a minute to review the BankCustomerExtensions and BankAccountExtensions classes.

    Notice that ...

1. Open the Program.cs file and take a minute to review the demonstration code.

    Notice that ...

1. Run the app and review the output in the terminal window.

    You should see the following output:

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

## Split the BankCustomer class into two partial class files

Partial classes allow you to split the definition of a class across multiple files. This can be useful when a class has a large number of properties and methods, or when you want to separate the definition of a class into logical sections. Splitting a class between two partial class files can make your code easier to read and maintain. For example, if the methods of a class are logically grouped into different categories, you can place each group of methods in a separate partial class file. This enables a team of developers to work on different parts of a class without interfering with each other's work. By using partial classes, you can organize your code more effectively and improve the readability and maintainability of your code.

In this task, you split the BankAccount class between two partial class files, moving the methods into a separate file.

Use the following steps to complete this section of the exercise:

1. Create a new class file for a class named **BankCustomerMethods**.

1. Update the BankCustomerMethods.cs file to include the following code:

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public partial class BankCustomer
    {

    }

    ```

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

1. Move the `FullName`, `UpdateName`, `DisplayCustomerInfo`, `Equals`, and `GetHashCode` methods to the BankCustomerMethods.cs file.

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
            return $"Customer ID: {customerId}, Name: {FullName()}";
        }
    
        // Override Equals method to compare customers by customerId
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;
    
            BankCustomer other = (BankCustomer)obj;
            return customerId == other.customerId;
        }
    
        // Override GetHashCode method
        public override int GetHashCode()
        {
            return customerId.GetHashCode();
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
        private string fName = "John";
        private string lName = "Doe";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
    
        public string FirstName
        {
            get { return fName; }
            set { fName = value; }
        }
    
        public string LastName
        {
            get { return lName; }
            set { lName = value; }
        }
    }

    ```

1. Run the app to ensure that your partial class updates didn't introduce any bugs.

    Splitting a class into two partial class files can improve code organization, but shouldn't affect the functionality of the app. The BankCustomer class should still work as expected, and you should see the same output in the terminal window.

    Verify that you see the following output:

    ```plaintext



    ```

## Create a static class for transactional BankAccount methods

Static classes are used to organize methods that don't require an instance of a class to be created. Static classes can't be instantiated, and their methods can be called directly without creating an instance of the class. Static classes are useful for grouping related methods together and providing a convenient way to access them. In this task, you create a static class named Transactions that holds methods for the BankAccount class. The Transactions class includes methods for depositing, withdrawing, transferring funds, and applying interest to a bank account.

Use the following steps to complete this section of the exercise:

1. Create a new class file for a class named **Transactions**.

    Transactions.cs

    ```csharp

    using System;
    
    namespace Classes_M3;
    
    public static class Transactions
    {

    }

    ```

1. Open the BankAccount.cs file.

1. Move the `Deposit`, `Withdraw`, `Transfer`, and `ApplyInterest` methods from the `BankAccount` class to the `Transactions` class.

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
            Balance += Balance * interestRate;
        }

    }

    ```

1. Update the methods in the Transactions class to use the `BankAccount` class as a parameter.

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
            account.Balance += account.Balance * BankAccount.interestRate;
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

1. Update the code to use the `Transactions` class for depositing, withdrawing, transferring funds, and applying interest to bank accounts.

    ```csharp

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

    ```

1. Take a minute to review your updated code files.

    Transactions.cs

    ```csharp
    
    using System;
    
    namespace Classes_M3;
    
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
    
    ```

    BankAccount.cs

    ```csharp
    
    using System;
    
    namespace Classes_M3;
    
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
    
    ```

    Program.cs

    ```csharp
    
    // Step 1: Create BankCustomer objects
    Console.WriteLine("Creating BankCustomer objects...");
    string firstName = "Tim";
    string lastName = "Shao";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Lisa";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Sandy";
    lastName = "Zoeng";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Step 2: Create BankAccount objects for customers
    Console.WriteLine("\nCreating BankAccount objects for customers...");
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");
    
    // Step 3: Demonstrate the use of BankCustomer properties
    Console.WriteLine("\nUpdating BankCustomer 1's name...");
    customer1.FirstName = "Thomas";
    customer1.LastName = "Margand";
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
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
    
    // Step 5: Demonstrate the use of extension methods
    Console.WriteLine("\nDemonstrating extension methods...");
    Console.WriteLine(customer1.GreetCustomer());
    Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
    Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
    Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");
    
    // Step 6: Display customer and account information
    Console.WriteLine("\nDisplaying customer and account information...");
    Console.WriteLine(customer1.DisplayCustomerInfo());
    Console.WriteLine(account1.DisplayAccountInfo());

    ```

1. Run the app to ensure that your static class updates didn't introduce any bugs.

    By moving the transactional methods to a static class, you can organize your code more effectively and improve the readability and maintainability of your code. The BankAccount class should still work as expected, and you should see the same output in the terminal window.

    Verify that you see the following output:

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
    
    ```

    The constructors in the BankAccount class can be improved by using optional parameters to provide default values, reducing the need for multiple constructor overloads.

1. Replace the two instance constructors with the following constructor that uses optional parameters:

    ```csharp
    
    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }
    
    ```

    By using optional parameters in the BankAccount constructor, you can create instances of `BankAccount` with varying levels of parameter detail, making class instantiation more flexible and reducing the need for multiple constructor overloads. For example, you can create a `BankAccount` object with only a `customerIdNumber`, or you can specify combinations of `balance` and `accountType` as well:

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

    ```

1. Run the app to ensure that your optional parameter updates didn't introduce any bugs.

    You should see the following output:

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

In this task, you implement copy constructors and object initializers by updating `BankCustomer`, `BankAccount`, and the demonstration code in Program.cs.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. To create a copy constructor for the BankCustomer class, add the following code:

    ```csharp

    // Copy constructor for BankCustomer
    public BankCustomer(BankCustomer existingCustomer)
    {

        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
        //this.customerId = existingCustomer.customerId;
        this.customerId = (nextCustomerId++).ToString("D10");

    }

    ```

    Notice that the `customerId` field from the existing customer isn't used. Instead, a new `customerId` is generated for the new customer. This supports the logic already implemented by the BankCustomer class.

1. Open the BankAccount.cs file.

1. To create a copy constructor for the BankAccount class, add the following code:

    ```csharp

    // Copy constructor for BankAccount
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }
    ```

    Notice that a new `AccountNumber` field is generated for the new account. The `CustomerId`, `Balance`, and `AccountType` fields are copied from the existing account. The `interestRate` field is not copied because it's a static field that's shared across all instances of the BankAccount class. The `customerId` field is copied because the intension is to create a new account for the same customer.

1. Open the Program.cs file.

1. Add the following Step 7 code to the end of the Program.cs file

    ```csharp

    // Step 7: Demonstrate using object initializers and copy constructors
    Console.WriteLine("\nDemonstrating object initializers and copy constructors...");
    
    // Using object initializer
    BankCustomer customer4 = new BankCustomer("Mikaela", "Lee") { FirstName = "Mikaela", LastName = "Lee" };
    Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.customerId}");
    
    // Using copy constructor
    BankCustomer customer5 = new BankCustomer(customer4);
    Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.customerId}");
    
    BankAccount account4 = new BankAccount(customer4.customerId, 3000, "Savings");
    BankAccount account5 = new BankAccount(account4);
    Console.WriteLine($"Account 4: Account # {account4.AccountNumber}, type {account4.AccountType}, balance {account4.Balance}, rate {BankAccount.interestRate}, customer ID {account4.CustomerId}");
    Console.WriteLine($"Account 5 (copy of account4): Account # {account5.AccountNumber}, type {account5.AccountType}, balance {account5.Balance}, rate {BankAccount.interestRate}, customer ID {account5.CustomerId}");

    ```

    Notice the following:

    - The `customer4` object is created using an object initializer. The `FirstName` and `LastName` properties are set using the object initializer syntax.
    - The `customer5` object is created using a copy constructor. The `customer5` object is a copy of the `customer4` object.
    - The `account4` object is created using an object initializer. The `Balance` and `AccountType` properties are set using the object initializer syntax.
    - The `account5` object is created using a copy constructor. The `account5` object is a copy of the `account4` object.

1. Run the app and review the output in the terminal window.

    You should see the following output:

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
