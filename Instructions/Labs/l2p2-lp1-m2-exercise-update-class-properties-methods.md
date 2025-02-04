---
lab:
    title: 'Exercise - Update a class with properties and methods in C#'
    module: 'Implement properties and methods in C# classes'
---


# Update a class with properties and methods in CSharp

In this exercise, you encapsulate the data and behavior of a class by implementing properties and methods.

This exercise includes the following tasks:

1. Review the existing code
1. Create properties for the BankCustomer class
1. Create automatically implemented properties for the BankAccount class
1. Create read-only properties for the BankAccount class
1. Create methods for the BankCustomer and BankAccount classes
1. Create extension methods for the BankCustomer and BankAccount classes
1. Update the Program.cs file to demonstrate the updated classes, properties, and methods

This exercise should take approximately **30** minutes to complete.

## Before you start

Before you can start this exercise, you will need to...

1. Ensure that you have the latest LTS version of the .NET SDK installed on your computer. You can download the latest version of the .NET SDK from the following URL: [https://dotnet.microsoft.com/download](https://dotnet.microsoft.com/download)
1. Ensure that you have Visual Studio Code installed on your computer. You can download Visual Studio Code from the following URL: [https://code.visualstudio.com/](https://code.visualstudio.com/)
1. Ensure that you have the C# Dev Kit configured in Visual Studio Code.

For addition help configuring the Visual Studio Code environment, see [https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/](https://learn.microsoft.com/en-us/training/modules/install-configure-visual-studio-code/)

## Review the existing code

In this task, you open an existing project and review the code.

Use the following steps to complete this section of the exercise:

1. Open Visual Studio Code.

1. Open the BankCustomer.cs file.

1. Take a minute to review the BankCustomer class.

    ```csharp

    using System;
    
    namespace Classes_M2;
    
    public class BankCustomer
    {
        private static int nextCustomerId;
        public string fName = "John";
        public string lName = "Doe";
        public readonly string customerId;
    
        static BankCustomer()
        {
            Random random = new Random();
            nextCustomerId = random.Next(10000000, 20000000);
        }
    
        public BankCustomer(string firstName, string lastName)
        {
            fName = firstName;
            lName = lastName;
            this.customerId = (nextCustomerId++).ToString("D10");
        }
        
    }

    ```

    Notice that the `BankCustomer` class ...

1. Open the BankAccount.cs file.

1. Take a minute to review the BankCustomer class.

    ```csharp

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

    ```

    Notice that the BankAccount class ...

1. Open the Program.cs file.

1. Take a minute to review the code.

    ```csharp

    using Classes_M2;
    
    string firstName = "John";
    string lastName = "Doe";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.fName} {customer1.lName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.fName} {customer2.lName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.fName} {customer3.lName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");

    ```

    Notice that the top level code ...

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    BankCustomer 1: John Doe 0014653176
    BankCustomer 2: Jane Doe 0014653177
    BankCustomer 3: Leonardo Rossi 0014653178
    Account 1: Account # 12885967, type Checking, balance 0, rate 0, customer ID 0014653176
    Account 2: Account # 12885968, type Checking, balance 1500, rate 0, customer ID 0014653177
    Account 3: Account # 12885969, type Checking, balance 2500, rate 0, customer ID 0014653178

    ```

## Create properties for the BankCustomer class

In this task, you create properties for the BankCustomer class using `get` and `set` property accessors. You also update the Program.cs file to use the new properties.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. next step

1. next step

1. next step

1. Take a minute to review your code.

    ```csharp

    public class BankCustomer
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

    ```csharp

    string firstName = "John";
    string lastName = "Doe";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Johnny";
    customer1.LastName = "Doe-Smith";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    
    Console.WriteLine($"Account 1: Account # {account1.accountNumber}, type {account1.accountType}, balance {account1.balance}, rate {BankAccount.interestRate}, customer ID {account1.customerId}");
    Console.WriteLine($"Account 2: Account # {account2.accountNumber}, type {account2.accountType}, balance {account2.balance}, rate {BankAccount.interestRate}, customer ID {account2.customerId}");
    Console.WriteLine($"Account 3: Account # {account3.accountNumber}, type {account3.accountType}, balance {account3.balance}, rate {BankAccount.interestRate}, customer ID {account3.customerId}");


    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Create automatically implemented properties for the BankAccount class

In this task, you create automatically implemented properties for the BankAccount class.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Notice that the BankAccount class has four data fields that are currently public: `accountNumber`, `balance`, `accountType`, and `customerId`.

    - `balance` is a read-write field that can be changed at any time.
    - `accountType` is a read-write field that can be changed at any time.
    - `accountNumber` is a read-only field that is set in the constructor and cannot be changed after that.
    - `customerId` is a read-only field that is set in the constructor and cannot be changed after that.

1. next step

1. next step

1. Take a minute to review your code.

    ```csharp

    public class BankAccount
    {
        private static int nextAccountNumber;
        public readonly int accountNumber;
        public static double interestRate;
        public readonly string customerId;
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
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;
        }
    
        public BankAccount(string customerIdNumber, double balance, string accountType)
        {
            this.accountNumber = nextAccountNumber++;
            this.customerId = customerIdNumber;
            this.Balance = balance;
            this.AccountType = accountType;
        }
    }
    
    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Create read-only properties for the BankAccount class

In this task, you create read-only properties in the BankAccount classes.

Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. next step

1. next step

1. next step

1. Take a minute to review your code.

    ```csharp

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
    }

    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Create methods for the BankCustomer and BankAccount classes

In this task, you create methods for the BankCustomer and BankAccount classes. The BankCustomer class has two methods: `FullName` and `UpdateName`. The BankAccount class has four methods: `Deposit`, `Withdraw`, `Transfer`, and `ApplyInterest`.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. next step

1. next step

1. Open the BankAccount.cs file.

1. next step

1. next step

1. Take a minute to review your code.

    BankCustomer.cs

    ```csharp

    public class BankCustomer
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

    BankAccount.cs

    ```csharp

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
    
        // Method to display account information
        public string DisplayAccountInfo()
        {
            return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
        }
    
        // Method to apply interest to the account balance
        public void ApplyInterest()
        {
            Balance += Balance * interestRate;
        }
    }

    ```

1. Update the Program.cs file to implement the methods.

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Create extension methods for the BankCustomer and BankAccount classes

In this task, you create extension methods for the BankCustomer and BankAccount classes.

Use the following steps to complete this section of the exercise:

1. Create an Extension.cs class file.

1. next step

1. next step

1. Review the extension methods:

    ```C#

    using System;
    
    namespace Classes_M2
    {
        public static class BankCustomerExtensions
        {
            // Extension method to check if the customer ID is valid
            public static bool IsValidCustomerId(this BankCustomer customer)
            {
                return customer.customerId.Length == 10;
            }
    
            // Extension method to greet the customer
            public static string GreetCustomer(this BankCustomer customer)
            {
                return $"Hello, {customer.FirstName} {customer.LastName}!";
            }
        }
    
        public static class BankAccountExtensions
        {
            // Extension method to check if the account is overdrawn
            public static bool IsOverdrawn(this BankAccount account)
            {
                return account.Balance < 0;
            }
    
            // Extension method to check if a specified amount can be withdrawn
            public static bool CanWithdraw(this BankAccount account, double amount)
            {
                return account.Balance >= amount;
            }
        }
    }

    ```

1. Update the Program.cs file to implement the extension methods.

1. next step

1. next step

1. Review the updated Program.cs file:

    ```C#



    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Update the Program.cs file to demonstrate the updated classes, properties, and methods

In this task, you update the Program.cs file to demonstrate the following steps:

1. Create BankCustomer objects.
1. Create BankAccount objects for the instantiated customers.
1. Demonstrate the use of BankCustomer properties. For example, update the customer's name.
1. Demonstrate the use of BankAccount methods. For example, deposit, withdraw, transfer, apply interest.
1. Demonstrate the use of extension methods. For example, greet the customer, check if the customer ID is valid, check if the account is overdrawn, check if a specified amount can be withdrawn.
1. Display customer and account information using the DisplayCustomerInfo and DisplayAccountInfo methods. These methods are defined in the BankCustomer and BankAccount classes, respectively.

Use the following steps to complete this section of the exercise:

1. Open the Program.cs file.

1. Replace the existing code with the following code:

    ```csharp

    using Classes_M2;
    
    // Task 1
    
    string firstName = "John";
    string lastName = "Doe";
    
    BankCustomer customer1 = new BankCustomer(firstName, lastName);
    
    firstName = "Jane";
    BankCustomer customer2 = new BankCustomer(firstName, lastName);
    
    firstName = "Leonardo";
    lastName = "Rossi";
    BankCustomer customer3 = new BankCustomer(firstName, lastName);
    
    Console.WriteLine($"BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    Console.WriteLine($"BankCustomer 2: {customer2.FirstName} {customer2.LastName} {customer2.customerId}");
    Console.WriteLine($"BankCustomer 3: {customer3.FirstName} {customer3.LastName} {customer3.customerId}");
    
    // Create accounts for customers
    BankAccount account1 = new BankAccount(customer1.customerId);
    BankAccount account2 = new BankAccount(customer2.customerId, 1500, "Checking");
    BankAccount account3 = new BankAccount(customer3.customerId, 2500, "Checking");
    
    // Demonstrate the use of BankCustomer properties
    customer1.FirstName = "Johnny";
    customer1.LastName = "Doe-Smith";
    // customer1.customerId = "1234567890"; // This line will not compile
    
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
    Console.WriteLine($"Account 1: Account # {account1.AccountNumber}, type {account1.AccountType}, balance {account1.Balance}, rate {BankAccount.interestRate}, customer ID {account1.CustomerId}");
    Console.WriteLine($"Account 2: Account # {account2.AccountNumber}, type {account2.AccountType}, balance {account2.Balance}, rate {BankAccount.interestRate}, customer ID {account2.CustomerId}");
    Console.WriteLine($"Account 3: Account # {account3.AccountNumber}, type {account3.AccountType}, balance {account3.Balance}, rate {BankAccount.interestRate}, customer ID {account3.CustomerId}");
    
    // Demonstrate the use of BankAccount methods
    account1.Deposit(500);
    Console.WriteLine($"Account 1 after deposit: Balance = {account1.Balance}");
    
    bool withdrawSuccess = account2.Withdraw(200);
    Console.WriteLine($"Account 2 after withdrawal: Balance = {account2.Balance}, Withdrawal successful: {withdrawSuccess}");
    
    bool transferSuccess = account3.Transfer(account1, 300);
    Console.WriteLine($"Account 3 after transfer: Balance = {account3.Balance}, Transfer successful: {transferSuccess}");
    Console.WriteLine($"Account 1 after receiving transfer: Balance = {account1.Balance}");
    
    account1.ApplyInterest();
    Console.WriteLine($"Account 1 after applying interest: Balance = {account1.Balance}");
    
    // Demonstrate the use of extension methods
    Console.WriteLine(customer1.GreetCustomer());
    Console.WriteLine($"Is customer1 ID valid? {customer1.IsValidCustomerId()}");
    Console.WriteLine($"Can account2 withdraw 2000? {account2.CanWithdraw(2000)}");
    Console.WriteLine($"Is account3 overdrawn? {account3.IsOverdrawn()}");
    
    // Display customer and account information
    Console.WriteLine(customer1.DisplayCustomerInfo());
    Console.WriteLine(account1.DisplayAccountInfo());

    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: John Doe 0012396421
    BankCustomer 2: Jane Doe 0012396422
    BankCustomer 3: Leonardo Rossi 0012396423
    
    Creating BankAccount objects for customers...
    Account 1: Account # 11657161, type Checking, balance 0, rate 0, customer ID 0012396421
    Account 2: Account # 11657162, type Checking, balance 1500, rate 0, customer ID 0012396422
    Account 3: Account # 11657163, type Checking, balance 2500, rate 0, customer ID 0012396423
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Johnny Doe-Smith 0012396421
    
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
    Hello, Johnny Doe-Smith!
    Is customer1 ID valid? True
    Can account2 withdraw 2000? False
    Is account3 overdrawn? False
    
    Displaying customer and account information...
    Customer ID: 0012396421, Name: Johnny Doe-Smith
    Account Number: 11657161, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0012396421

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.
