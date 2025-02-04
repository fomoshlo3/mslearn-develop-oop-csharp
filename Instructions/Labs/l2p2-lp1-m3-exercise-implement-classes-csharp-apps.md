---
lab:
    title: 'Exercise - Implement classes in C# applications'
    module: 'Implement classes in C# applications'
---


# Implement classes in C# applications

In this exercise, you encapsulate the data and behavior of a class by implementing properties and methods.

This exercise includes the following tasks:

1. Review the existing code
1. Split the ABC class into partial classes
1. Create a static class that holds methods for the XYZ class
1. Update methods in the XYZ class using named and optional parameters
1. Implement object initializers and copy constructors

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
    
    namespace Classes_M3;
    
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

    Notice that the `BankCustomer` class ...

1. Open the BankAccount.cs file.

1. Take a minute to review the BankCustomer class.

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

    Notice that the BankAccount class ...

1. Open the Extensions.cs file.

1. Take a minute to review the extension methods that support the BankCustomer and BankAccount classes.

    ```csharp

    using System;
    
    namespace Classes_M3;
    
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
    using Classes_M3;

    // Step 1: Create BankCustomer objects
    Console.WriteLine("Creating BankCustomer objects...");
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
    customer1.FirstName = "Johnny";
    customer1.LastName = "Doe-Smith";
    Console.WriteLine($"Updated BankCustomer 1: {customer1.FirstName} {customer1.LastName} {customer1.customerId}");
    
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

    Notice that the top level code ...

1. Run the app and review the output in the terminal window.

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

## Task 2: Split the BankCustomer class into partial class files

In this task, you split the BankAccount class between two partial class files, moving the methods into a separate file.

Use the following steps to complete this section of the exercise:

1. Create a class file named BankCustomerMethods.cs.

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

    }

    ```

1. Move the `FullName`, `UpdateName`, `DisplayCustomerInfo`, `Equals`, and `GetHashCode` methods to the BankCustomerMethods.cs file.

1. Take a minute to review your code.

    ```csharp


    
    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Task 3: Create static classes

Create a static class named Transactions that holds methods for the BankAccount class

Create a new class named AccountTypes that holds the account types for the BankAccount class

1. Create a class file named Transactions.cs.

1. Open the BankAccount.cs file.

1. Move the `Deposit`, `Withdraw`, `Transfer`, and `ApplyInterest` methods to the Transactions.cs file.

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

    Program.cs (Step 4 is updated)

    ```csharp
    
    // Step 1: Create BankCustomer objects
    Console.WriteLine("Creating BankCustomer objects...");
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
    customer1.FirstName = "Johnny";
    customer1.LastName = "Doe-Smith";
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



1. Take a minute to review your code.

    ```csharp

    
    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Task 4: Update a constructor using optional parameters

In this task, you update a constructor in the BankAccount class using optional parameters.

Using named and optional parameters can improve code readability and flexibility, especially in constructors and methods with multiple parameters. In this workspace, the files that would benefit the most from named and optional parameters are BankAccount.cs and Transactions.cs.

The constructors in the BankAccount class can be improved by using optional parameters to provide default values, reducing the need for multiple constructor overloads.

```csharp

public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
{
    this.AccountNumber = nextAccountNumber++;
    this.CustomerId = customerIdNumber;
    this.Balance = balance;
    this.AccountType = accountType;
}

```

By using optional parameters in the BankAccount constructor, you can create instances of BankAccount with varying levels of detail, making the code more flexible and reducing the need for multiple constructor overloads.

```csharp

using Classes_M3;

class Program
{
    static void Main(string[] args)
    {
        // Using the constructor with optional parameters
        BankAccount account1 = new BankAccount("C12345");
        BankAccount account2 = new BankAccount("C67890", 500);
        BankAccount account3 = new BankAccount("C54321", 1000, "Savings");

        Console.WriteLine(account1.DisplayAccountInfo());
        Console.WriteLine(account2.DisplayAccountInfo());
        Console.WriteLine(account3.DisplayAccountInfo());
    }
}

```


Use the following steps to complete this section of the exercise:

1. Open the BankAccount.cs file.

1. Delete the following constructor.

    ```csharp

    public BankAccount(string customerIdNumber)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
    }

    ```

1. Update the constructor to use optional parameters.

    ```csharp

    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    ```

1. Take a minute to review your code.

    ```csharp

    
    ```

1. Run the app

1. Review the output in the terminal window.

    You should see the following output:

    ```plaintext

    ```

## Task 5: Implement object initializers and copy constructors



You can use object initializers and copy constructors to improve the existing code. Both techniques can enhance code readability and maintainability.

### Object Initializers

Object initializers allow you to initialize an object and set its properties in a single statement. This can make the code more concise and readable.

Example:

Instead of:

```csharp

BankAccount account1 = new BankAccount("1234567890");
account1.Balance = 1000;
account1.AccountType = "Savings";

```

You can use:

```csharp

BankAccount account1 = new BankAccount("1234567890")
{
    Balance = 1000,
    AccountType = "Savings"
};

```



### Copy Constructors

Copy constructors allow you to create a new object that is a copy of an existing object. This is useful when you need to duplicate objects with the same state.

Example:

```csharp

public BankAccount(BankAccount existingAccount)
{
    this.AccountNumber = existingAccount.AccountNumber;
    this.CustomerId = existingAccount.CustomerId;
    this.Balance = existingAccount.Balance;
    this.AccountType = existingAccount.AccountType;
}

```


### Where to Use Object Initializers and Copy Constructors

#### Object Initializers

You can use object initializers in the Program.cs file where you are creating instances of BankAccount and BankCustomer.

Example:

```csharp

BankAccount account1 = new BankAccount("1234567890")
{
    Balance = 1000,
    AccountType = "Savings"
};

BankCustomer customer1 = new BankCustomer("John", "Doe")
{
    FirstName = "Johnny",
    LastName = "Doe-Smith"
};

```

#### opy Constructors

You can add copy constructors to the BankAccount and BankCustomer classes to facilitate copying objects.

Example:

```csharp

public BankAccount(BankAccount existingAccount)
{
    this.AccountNumber = existingAccount.AccountNumber;
    this.CustomerId = existingAccount.CustomerId;
    this.Balance = existingAccount.Balance;
    this.AccountType = existingAccount.AccountType;
}

// filepath: /path/to/CUSTOMER.CS
public BankCustomer(BankCustomer existingCustomer)
{
    this.customerId = existingCustomer.customerId;
    this.FirstName = existingCustomer.FirstName;
    this.LastName = existingCustomer.LastName;
}

```

### Updated Code with Object Initializers and Copy Constructors

ACCOUNT.CS

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

    public BankAccount(string customerIdNumber, double balance = 0, string accountType = "Checking")
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = customerIdNumber;
        this.Balance = balance;
        this.AccountType = accountType;
    }

    // Add a copy constructor here
    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = existingAccount.AccountNumber;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }

    // Method to display account information
    public string DisplayAccountInfo()
    {
        return $"Account Number: {AccountNumber}, Type: {AccountType}, Balance: {Balance}, Interest Rate: {interestRate}, Customer ID: {CustomerId}";
    }
}

```

CUSTOMER.CS

```csharp

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

    // Add a copy constructor here
    public BankCustomer(BankCustomer existingCustomer)
    {
        this.customerId = existingCustomer.customerId;
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
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

By using object initializers and copy constructors, you can make your code more concise, readable, and easier to maintain.




In this task, you update the `Main` method using object initializers and copy constructors.

Use the following steps to complete this section of the exercise:

1. Open the BankCustomer.cs file.

1. Add the copy constructor to the BankCustomer class.

    ```csharp

    public BankCustomer(BankCustomer existingCustomer)
    {
        this.customerId = existingCustomer.customerId;
        this.FirstName = existingCustomer.FirstName;
        this.LastName = existingCustomer.LastName;
    }

    ```

1. Open the BankAccount.cs file.

1. Add the copy constructor to the BankAccount class.

    ```csharp

    public BankAccount(BankAccount existingAccount)
    {
        this.AccountNumber = nextAccountNumber++;
        this.CustomerId = existingAccount.CustomerId;
        this.Balance = existingAccount.Balance;
        this.AccountType = existingAccount.AccountType;
    }
    ```

1. Open the Program.cs file.

1. Add the following Step 7 code to the end of the Program.cs file

    ```csharp

    // Step 7: Demonstrate using object initializers and copy constructors
    Console.WriteLine("\nDemonstrating object initializers and copy constructors...");
    
    // Using object initializer
    BankCustomer customer4 = new BankCustomer("Alice", "Smith") { FirstName = "Alicia", LastName = "Smith-Jones" };
    Console.WriteLine($"BankCustomer 4: {customer4.FirstName} {customer4.LastName} {customer4.customerId}");
    
    // Using copy constructor
    BankCustomer customer5 = new BankCustomer(customer4);
    Console.WriteLine($"BankCustomer 5 (copy of customer4): {customer5.FirstName} {customer5.LastName} {customer5.customerId}");
    
    BankAccount account4 = new BankAccount(customer4.customerId, 3000, "Savings");
    BankAccount account5 = new BankAccount(account4);
    Console.WriteLine($"Account 4: Account # {account4.AccountNumber}, type {account4.AccountType}, balance {account4.Balance}, rate {BankAccount.interestRate}, customer ID {account4.CustomerId}");
    Console.WriteLine($"Account 5 (copy of account4): Account # {account5.AccountNumber}, type {account5.AccountType}, balance {account5.Balance}, rate {BankAccount.interestRate}, customer ID {account5.CustomerId}");

    ```

1. Take a minute to review your code.

    ```csharp

    
    ```

1. Run the app and review the output in the terminal window.

    You should see the following output:

    ```plaintext

    Creating BankCustomer objects...
    BankCustomer 1: John Doe 0019904379
    BankCustomer 2: Jane Doe 0019904380
    BankCustomer 3: Leonardo Rossi 0019904381
    
    Creating BankAccount objects for customers...
    Account 1: Account # 13535677, type Checking, balance 0, rate 0, customer ID 0019904379
    Account 2: Account # 13535678, type Checking, balance 1500, rate 0, customer ID 0019904380
    Account 3: Account # 13535679, type Checking, balance 2500, rate 0, customer ID 0019904381
    
    Updating BankCustomer 1's name...
    Updated BankCustomer 1: Johnny Doe-Smith 0019904379
    
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
    Customer ID: 0019904379, Name: Johnny Doe-Smith
    Account Number: 13535677, Type: Checking, Balance: 800, Interest Rate: 0, Customer ID: 0019904379
    
    Demonstrating object initializers and copy constructors...
    BankCustomer 4: Alicia Smith-Jones 0019904382
    BankCustomer 5 (copy of customer4): Alicia Smith-Jones 0019904382
    Account 4: Account # 13535680, type Savings, balance 3000, rate 0, customer ID 0019904382
    Account 5 (copy of account4): Account # 13535680, type Savings, balance 3000, rate 0, customer ID 0019904382

    ```

## Clean up

Now that you've finished the exercise, consider archiving your project files for review at a later time. Having your own projects available for review can be a valuable resource when you're learning to code. Also, building up a portfolio of projects can be a great way to demonstrate your skills to potential employers.






**The following code uses a static class for account types**

Static class for account types

```csharp

public static class AccountTypes
{
    public static readonly string[] Types = { "Checking", "Savings", "MoneyMarket" };
}

```

CheckingAccount.cs

```csharp

public class CheckingAccount
{
    private static int nextAccountNumber;
    public readonly int accountNumber;
    public double balance = 0;
    public static double interestRate;
    public string accountType;

    static CheckingAccount()
    {
        Random random = new Random();
        nextAccountNumber = random.Next(10000000, 20000000);
        interestRate = 0;
    }

    public CheckingAccount() : this(0, AccountTypes.Types[0]) { }

    public CheckingAccount(double balance, string accountType)
    {
        if (!AccountTypes.Types.Contains(accountType))
        {
            throw new ArgumentException("Invalid account type");
        }

        this.accountNumber = nextAccountNumber++;
        this.balance = balance;
        this.accountType = accountType;
        Console.WriteLine($"Account created: account# {accountNumber}, balance {balance}, rate {interestRate}, type {accountType}");
    }
}

```

Program.cs

```csharp

using Classes_M1;

public class Program
{
    public static void Main(string[] args)
    {
        CheckingAccount checkingAccount = new CheckingAccount(500, AccountTypes.Types[0]);
        CheckingAccount savingsAccount = new CheckingAccount(1000, AccountTypes.Types[1]);
        CheckingAccount moneyMarketAccount = new CheckingAccount(1500, AccountTypes.Types[2]);

        Console.WriteLine($"Checking Account: Account # {checkingAccount.accountNumber}, type {checkingAccount.accountType}, balance {checkingAccount.balance}, rate {CheckingAccount.interestRate}");
        Console.WriteLine($"Savings Account: Account # {savingsAccount.accountNumber}, type {savingsAccount.accountType}, balance {savingsAccount.balance}, rate {CheckingAccount.interestRate}");
        Console.WriteLine($"Money Market Account: Account # {moneyMarketAccount.accountNumber}, type {moneyMarketAccount.accountType}, balance {moneyMarketAccount.balance}, rate {CheckingAccount.interestRate}");
    }
}

```
